namespace CarAuctionSystem.Core.Contracts
{
	using Models.Auction;
	using Models.Bid;

	public interface IAuctionService
	{
		Task<AuctionQueryModel> GetAllAuctions(string? transmissionType = null,
			string? carBodyType = null,
			string? searchTerm = null,
			AuctionSorting sorting = AuctionSorting.Newest);

		Task Create(AddAuctionModel model, string userId);

		Task<bool> ExistsById(int id);

		Task<AuctionDetailsModel> GetAuctionDetailsById(int id);

		Task PlaceBid(BidFormModel model, string userId);

		Task<List<BidViewModel>> GetAllBids(int id);
	}
}
