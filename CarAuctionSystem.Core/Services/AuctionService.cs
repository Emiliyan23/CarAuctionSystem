namespace CarAuctionSystem.Core.Services
{
	using Contracts;
	using Infrastructure.Data.Common;
	using Infrastructure.Data.Models;
	using Microsoft.EntityFrameworkCore;
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
			return await _repo.AllReadonly<Auction>().Select(a => new AllAuctionModel
			{
				Id = a.Id,
				Make = a.Make.Name,
				Model = a.Model,
				ModelYear = a.ModelYear,
				Mileage = a.Mileage,
			}).ToListAsync();
		}


		public async Task Create(AddAuctionModel model, string userId)
		{
			var auction = new Auction
			{
				StartDate = DateTime.UtcNow,
				EndDate = DateTime.UtcNow.AddDays(model.AuctionDuration),
				SellerId = Guid.Parse(userId),
				MakeId = model.MakeId,
				Model = model.Model,
				CarBodyId = model.CarBodyId,
				DrivetrainId = model.DrivetrainId,
				TransmissionId = model.TransmissionId,
				FuelId = model.FuelId,
				ModelYear = model.ModelYear,
				Vin = model.Vin,
				Mileage = model.Mileage,
				InteriorColor = model.InteriorColor,
				ExteriorColor = model.ExteriorColor,
				EngineDetails = model.EngineDetails
			};

			await _repo.AddAsync(auction);
			await _repo.SaveChangesAsync();
		}
	}
}
