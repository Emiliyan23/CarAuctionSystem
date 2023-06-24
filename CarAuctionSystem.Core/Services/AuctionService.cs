namespace CarAuctionSystem.Core.Services
{
	using Contracts;
	using Infrastructure.Data.Common;
	using Infrastructure.Data.Models;
	using Models.Auction;

	public class AuctionService : IAuctionService
	{
		private readonly IRepository _repo;

		public AuctionService(IRepository repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<AllAuctionModel>> GetAllAuctions()
		{
			return _repo.AllReadonly<Auction>().Select(a => new AllAuctionModel
			{
				Make = a.Make.Name,
				Model = a.Model,
				ModelYear = a.ModelYear,
				Mileage = a.Mileage,
			});
		}
	}
}
