namespace CarAuctionSystem.Core.Contracts
{
	using Models.Auction;
	using Models.Bid;
	using Models.Statistics;

	public interface IAuctionService
	{
		Task<AuctionQueryModel> GetAllAuctions(string? transmissionType = null,
			string? carBodyType = null,
			string? searchTerm = null,
			AuctionSorting sorting = AuctionSorting.Newest);

		Task<List<PendingAuctionModel>> GetAllPendingAuctions();

		Task<PendingAuctionDetailsModel> GetPendingAuctionDetailsById(int id);

		Task Create(AuctionFormModel model, string userId);

		Task<bool> ExistsById(int id);

		Task<AuctionDetailsModel> GetAuctionDetailsById(int id, string userId);

		Task PlaceBid(BidFormModel model, string userId);

		Task<List<BidViewModel>> GetAllBids(int id);

		Task<StatisticsServiceModel> GetStatistics();

		Task ApproveAuction(int id);

		Task<bool> AuctionIsApproved(int id);
	}
}
