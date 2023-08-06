namespace CarAuctionSystem.Services.Data.Contracts
{
	using Models.Bid;

	public interface IBidService
	{
		Task<List<BidServiceModel>> All();
	}
}
