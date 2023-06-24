namespace CarAuctionSystem.Core.Contracts
{
	using Models.Auction;

	public interface IAuctionService
	{
		Task<IEnumerable<AllAuctionModel>> GetAllAuctions();
	}
}
