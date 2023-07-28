namespace CarAuctionSystem.Services.Data
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using CarAuctionSystem.Data.Models;
    using CarAuctionSystem.Data.Repositories;
    using Contracts;
    using Common;
    using Web.ViewModels.Auction;
    using Web.ViewModels.User;

    public class UserService : IUserService
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IRepository repo)
        {
            _repo = repo;
            _mapper = MapperConfig.InitializeMapper();
        }
        public async Task<bool> UserExists(string userId)
        {
            return await _repo.AllReadonly<ApplicationUser>()
                .AnyAsync(u => u.Id == Guid.Parse(userId));
        }

        public async Task<UserProfileModel> GetUserProfile(string userId)
        {
            var user = await _repo.AllReadonly<ApplicationUser>()
                .Include(u => u.Auctions.Where(a => a.IsApproved))
                .Include(u => u.Bids)
                .Where(u => u.Id == Guid.Parse(userId))
                .Select(u => new UserProfileModel
                {
                    UserId = userId,
                    Username = u.UserName
                })
                .FirstOrDefaultAsync();

            user!.Auctions = await _repo.AllReadonly<Auction>()
                .Where(a => a.SellerId.ToString() == userId)
                .OrderByDescending(a => a.StartDate)
                .Select(a => new AuctionViewModel
                {
                    Id = a.Id,
                    Make = a.Make.Name,
                    Model = a.Model,
                    ModelYear = a.ModelYear,
                    Mileage = a.Mileage,
                    EndDate = a.EndDate ?? DateTime.MinValue,
                    ImageUrl = a.ImageUrl
                })
                .ToListAsync();

            user.Bids = await _repo.AllReadonly<Bid>()
                .Where(b => b.BidderId.ToString() == userId)
                .OrderByDescending(b => b.BidDate)
                .Select(b => new UserBidModel
                {
                    BidderUsername = b.Bidder.UserName,
                    BidderId = b.BidderId.ToString(),
                    BidAmount = b.BidAmount,
                    BidDate = b.BidDate,
                    AuctionId = b.AuctionId,
                    Make = b.Auction.Make.Name,
                    Model = b.Auction.Model
                }).ToListAsync();

            return user;
        }

        public async Task<string?> GetSellerIdByAuctionId(int auctionId)
        {
            return await _repo.AllReadonly<ApplicationUser>()
                .Where(u => u.Auctions.Any(a => a.Id == auctionId))
                .Select(u => u.Id.ToString().ToLower())
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AuctionIsInWatchlist(int id, string userId)
        {
            var watchedAuction = await _repo.AllReadonly<WatchedAuction>()
                .Where(a => a.AuctionId == id && a.UserId == Guid.Parse(userId))
                .FirstOrDefaultAsync();

            return watchedAuction != null;
        }

        public async Task<IEnumerable<AuctionViewModel>> GetWatchlist(string userId)
        {
            var watchlist = await _repo.AllReadonly<WatchedAuction>()
                .Where(a => a.UserId == Guid.Parse(userId))
                .Select(a => new AuctionViewModel
                {
                    Id = a.AuctionId,
                    Make = a.Auction.Make.Name,
                    Model = a.Auction.Model,
                    ModelYear = a.Auction.ModelYear,
                    Mileage = a.Auction.Mileage,
                    ImageUrl = a.Auction.ImageUrl,
                    EndDate = a.Auction.EndDate ?? DateTime.MinValue
                })
                .ToListAsync();

            return watchlist;
        }

        public async Task AddToWatchlist(int id, string userId)
        {
            var watchedAuction = new WatchedAuction
            {
                AuctionId = id,
                UserId = Guid.Parse(userId)
            };

            await _repo.AddAsync(watchedAuction);
            await _repo.SaveChangesAsync();
        }

        public async Task RemoveFromWatchlist(int id, string userId)
        {
            var watchedAuction = await _repo.All<WatchedAuction>()
                .Where(wa => wa.AuctionId == id && wa.UserId == Guid.Parse(userId))
                .FirstOrDefaultAsync();

            await _repo.DeleteAsync<WatchedAuction>(watchedAuction.Id);
            await _repo.SaveChangesAsync();
        }
    }
}
