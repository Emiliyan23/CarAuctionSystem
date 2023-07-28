namespace CarAuctionSystem.Services.Data.Contracts
{
	using Models.Statistics;
	using Web.ViewModels.Auction;
	using Web.ViewModels.Bid;

	public interface IAuctionService
	{
		Task<AuctionQueryModel> GetAllAuctions(string? transmissionType = null,
			string? carBodyType = null,
			string? searchTerm = null,
			AuctionSorting sorting = AuctionSorting.Newest);

		Task<List<PendingAuctionModel>> GetAllPendingAuctions();

		Task<List<PendingAuctionModel>> GetAllPendingAuctionsByUserId(string userId);

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
