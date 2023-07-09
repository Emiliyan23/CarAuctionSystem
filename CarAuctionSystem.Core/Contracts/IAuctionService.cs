namespace CarAuctionSystem.Core.Contracts
{
	using Models.Auction;
	using Models.Bid;

	public interface IAuctionService
	{
		Task<IEnumerable<AllAuctionModel>> GetAllAuctions();

		Task Create(AddAuctionModel model, string userId);

		Task<bool> ExistsById(int id);

		Task<AuctionDetailsModel> GetAuctionDetailsById(int id);

		Task PlaceBid(BidFormModel model, string userId);
	}
}
