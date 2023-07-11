namespace CarAuctionSystem.Core.Contracts
{
	using Models.Auction;
	using Models.Bid;

	public interface IAuctionService
	{
		Task<AuctionQueryModel> GetAllAuctions(string? searchTerm = null,
			AuctionSorting sorting = AuctionSorting.Newest,
			int currentPage = 1,
			int auctionsPerPage = 1);

		Task Create(AddAuctionModel model, string userId);

		Task<bool> ExistsById(int id);

		Task<AuctionDetailsModel> GetAuctionDetailsById(int id);

		Task PlaceBid(BidFormModel model, string userId);

		Task<List<BidViewModel>> GetAllBids(int id);
	}
}
