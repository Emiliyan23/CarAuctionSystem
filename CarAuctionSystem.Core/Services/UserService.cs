namespace CarAuctionSystem.Core.Services
{
	using AutoMapper;
	using Common;
	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Infrastructure.Data;
	using Infrastructure.Data.Common;
	using Infrastructure.Data.Models;
	using Models.Auction;
	using Models.Bid;
	using Models.User;

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
				.Include(u => u.Auctions)
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
				.Select(a => new AllAuctionModel
				{
					Id = a.Id,
					Make = a.Make.Name,
					Model = a.Model,
					ModelYear = a.ModelYear,
					Mileage = a.Mileage,
					EndDate = a.EndDate,
					ImageUrl = a.ImageUrl
				})
				.ToListAsync();

			user.Bids = await _repo.AllReadonly<Bid>()
				.Where(b => b.BidderId.ToString() == userId)
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
	}
}
