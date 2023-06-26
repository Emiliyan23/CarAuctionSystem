namespace CarAuctionSystem.Core.Contracts
{
	using Models.Auction;

	public interface IAuctionService
	{
		Task<IEnumerable<AllAuctionModel>> GetAllAuctions();

		Task Create(AddAuctionModel model, string userId);

		Task<bool> ExistsById(int id);

		Task<AuctionDetailsModel> GetAuctionDetailsById(int id);
	}
}
