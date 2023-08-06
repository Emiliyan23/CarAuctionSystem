namespace CarAuctionSystem.Services.Data
{
	using Microsoft.EntityFrameworkCore;

	using CarAuctionSystem.Data.Models;
	using CarAuctionSystem.Data.Repositories;
	using Contracts;
	using Models.Bid;

	public class BidService : IBidService
	{
		private readonly IRepository _repo;

		public BidService(IRepository repo)
		{
			_repo = repo;
		}
		public async Task<List<BidServiceModel>> All()
		{
			var allBids = await _repo.AllReadonly<Bid>()
				.OrderByDescending(b => b.BidDate)
				.Select(b => new BidServiceModel
				{
					BidderId = b.BidderId.ToString()
						.ToLower(),
					BidderUsername = b.Bidder.UserName,
					BidAmount = b.BidAmount,
					BidTime = b.BidDate,
					AuctionId = b.AuctionId,
					ModelYear = b.Auction.ModelYear,
					Make = b.Auction.Make.Name,
					Model = b.Auction.Model
				})
				.ToListAsync();

			return allBids;
		}
	}
}
