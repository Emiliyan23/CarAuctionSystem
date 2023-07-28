namespace CarAuctionSystem.Services.Data
{
    using AutoMapper;
    using Microsoft.EntityFrameworkCore;

    using CarAuctionSystem.Data.Models;
    using CarAuctionSystem.Data.Repositories;
    using Common;
    using Contracts;
    using Models.Statistics;
    using Web.ViewModels.Auction;
    using Web.ViewModels.Bid;
    using Web.ViewModels.Seller;

    public class AuctionService : IAuctionService
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AuctionService(IRepository repo)
        {
            _repo = repo;
            _mapper = MapperConfig.InitializeMapper();
        }

        public async Task<AuctionQueryModel> GetAllAuctions(AllAuctionsQueryModel queryModel)
        {
            var result = new AuctionQueryModel();
            var auctions = _repo.AllReadonly<Auction>()
                .Where(a => a.IsApproved == true);

            if (queryModel.StartYear != null)
            {
	            auctions = auctions.Where(a => a.ModelYear  >= queryModel.StartYear.Value);
            }

            if (queryModel.EndYear != null)
            {
	            auctions = auctions.Where(a => a.ModelYear <= queryModel.EndYear.Value);
            }

            if (string.IsNullOrEmpty(queryModel.TransmissionType) == false)
            {
                auctions = auctions.Where(a => a.Transmission.Type == queryModel.TransmissionType);
            }

            if (string.IsNullOrEmpty(queryModel.CarBodyType) == false)
            {
                auctions = auctions.Where(a => a.CarBody.Type == queryModel.CarBodyType);
            }

            if (string.IsNullOrEmpty(queryModel.SearchTerm) == false)
            {
                string wildcard = $"%{queryModel.SearchTerm.ToLower()}%";
                auctions = auctions.Where(a => EF.Functions.Like(a.Make.Name.ToLower(), wildcard) ||
                                               EF.Functions.Like(a.Model.ToLower(), wildcard) ||
                                               EF.Functions.Like(a.EngineDetails.ToLower(), wildcard) ||
                                               EF.Functions.Like(a.Vin.ToLower(), wildcard));
            }

            auctions = queryModel.Sorting switch
            {
                AuctionSorting.Oldest => auctions.OrderBy(a => a.StartDate),
                AuctionSorting.LowestMileage => auctions.OrderBy(a => a.Mileage),
                _ => auctions.OrderBy(a => a.EndDate < DateTime.UtcNow)
                    .ThenByDescending(a => a.StartDate)
            };

            result.Auctions = await auctions
                .Select(a => new AuctionViewModel
                {
                    Id = a.Id,
                    Make = a.Make.Name,
                    Model = a.Model,
                    EndDate = a.EndDate ?? DateTime.MinValue,
                    ImageUrl = a.ImageUrl,
                    Mileage = a.Mileage,
                    ModelYear = a.ModelYear
                })
                .ToListAsync();

            result.TotalAuctions = await auctions.CountAsync();

            return result;
        }

        public async Task<List<PendingAuctionModel>> GetAllPendingAuctions()
        {
            var auctions = await _repo.All<Auction>()
                .Where(a => a.IsApproved == false)
                .Select(a => new PendingAuctionModel
                {
                    Id = a.Id,
                    Make = a.Make.Name,
                    Model = a.Model,
                    ModelYear = a.ModelYear
                })
                .ToListAsync();

            return auctions;
        }

        public async Task<List<PendingAuctionModel>> GetAllPendingAuctionsByUserId(string userId)
        {
            var auctions = await _repo.All<Auction>()
                .Where(a => a.IsApproved == false && a.SellerId == Guid.Parse(userId))
                .Select(a => new PendingAuctionModel
                {
                    Id = a.Id,
                    Make = a.Make.Name,
                    Model = a.Model,
                    ModelYear = a.ModelYear
                })
                .ToListAsync();

            return auctions;
        }

        public async Task<PendingAuctionDetailsModel> GetPendingAuctionDetailsById(int id)
        {
            var auction = await _repo.All<Auction>()
                .Where(a => a.Id == id)
                .Include(a => a.Make)
                .Include(a => a.Seller)
                .Include(a => a.Drivetrain)
                .Include(a => a.Transmission)
                .Include(a => a.Fuel)
                .Include(a => a.CarBody)
                .FirstOrDefaultAsync();

            var model = new PendingAuctionDetailsModel
            {
                Id = auction!.Id,
                ImageUrl = auction.ImageUrl,
                Make = auction.Make.Name,
                Model = auction.Model,
                ModelYear = auction.ModelYear,
                Vin = auction.Vin,
                InteriorColor = auction.InteriorColor,
                ExteriorColor = auction.ExteriorColor,
                EngineDetails = auction.EngineDetails,
                DrivetrainType = auction.Drivetrain.Type,
                TransmissionType = auction.Transmission.Type,
                FuelType = auction.Fuel.Type,
                CarBodyType = auction.CarBody.Type,
                Mileage = auction.Mileage,
                AuctionDuration = auction.AuctionDuration,
                SellerDetails = new SellerDetailsModel
                {
                    Id = auction.SellerId.ToString(),
                    Username = auction.Seller.UserName,
                    Email = auction.Seller.Email,
                    PhoneNumber = auction.Seller.PhoneNumber
                }
            };

            return model;
        }

        public async Task Create(AuctionFormModel model, string userId)
        {
            var auction = _mapper.Map<Auction>(model);
            auction.SellerId = Guid.Parse(userId);

            await _repo.AddAsync(auction);
            await _repo.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(int id)
        {
            return await _repo.AllReadonly<Auction>()
                .AnyAsync(a => a.Id == id);
        }

        public async Task<AuctionDetailsModel> GetAuctionDetailsById(int id, string userId)
        {
            var auction = await _repo.AllReadonly<Auction>()
                .Where(a => a.Id == id)
                .Include(a => a.Make)
                .Include(a => a.Seller)
                .Include(a => a.Drivetrain)
                .Include(a => a.Transmission)
                .Include(a => a.Fuel)
                .Include(a => a.CarBody)
                .FirstOrDefaultAsync();

            var model = _mapper.Map<AuctionDetailsModel>(auction);

            model.Watchlist = await _repo.AllReadonly<WatchedAuction>()
                .Where(wa => wa.UserId == Guid.Parse(userId))
                .Select(a => a.AuctionId)
                .ToListAsync();


            model.SellerDetails = new SellerDetailsModel
            {
                Id = auction!.SellerId.ToString(),
                Username = auction.Seller.UserName,
                Email = auction.Seller.Email,
                PhoneNumber = auction.Seller.PhoneNumber
            };

            model.Bids = await GetAllBids(id);

            return model;
        }

        public async Task PlaceBid(BidFormModel model, string userId)
        {
            var bid = new Bid
            {
                AuctionId = model.AuctionId,
                BidAmount = model.BidAmount,
                BidDate = DateTime.UtcNow,
                BidderId = Guid.Parse(userId)
            };

            await _repo.AddAsync(bid);
            await _repo.SaveChangesAsync();
        }

        public async Task<List<BidViewModel>> GetAllBids(int id)
        {
            List<Bid> bids = await _repo.AllReadonly<Bid>()
                .Where(b => b.AuctionId == id)
                .Include(b => b.Auction)
                .Include(b => b.Bidder)
                .ToListAsync();

            List<BidViewModel> bidModels = new List<BidViewModel>();
            foreach (var bid in bids)
            {
                var bidModel = new BidViewModel
                {
                    BidderId = bid.BidderId.ToString(),
                    BidderUsername = bid.Bidder.UserName,
                    BidAmount = bid.BidAmount,
                    BidDate = bid.BidDate
                };

                bidModels.Add(bidModel);
            }

            return bidModels;
        }

        public async Task<StatisticsServiceModel> GetStatistics()
        {
            return new StatisticsServiceModel
            {
                AuctionsCount = await _repo.All<Auction>()
                    .CountAsync(),
                SalesCount = await _repo.All<Auction>()
                    .Where(a => a.EndDate < DateTime.UtcNow && a.Bids.Any())
                    .CountAsync(),
                BidsCount = await _repo.All<Bid>()
                    .CountAsync()
            };
        }

        public async Task ApproveAuction(int id)
        {
            var auction = await _repo.GetByIdAsync<Auction>(id);
            if (auction.IsApproved == false)
            {
                auction.StartDate = DateTime.UtcNow;
                auction.EndDate = auction.StartDate.Value.AddDays(auction.AuctionDuration);
                auction.IsApproved = true;
            }

            await _repo.SaveChangesAsync();
        }

        public async Task<bool> AuctionIsApproved(int id)
        {
            var auction = await _repo.AllReadonly<Auction>()
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (auction!.IsApproved)
            {
                return true;
            }

            return false;
        }
    }
}
