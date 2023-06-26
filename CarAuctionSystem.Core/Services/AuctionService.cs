namespace CarAuctionSystem.Core.Services
{
	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Infrastructure.Data.Common;
	using Infrastructure.Data.Models;
	using Models.Auction;
	using Models.Seller;

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
				ImageUrl = a.ImageUrl,
				EndDate = a.EndDate,
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
				EngineDetails = model.EngineDetails,
				ImageUrl = model.ImageUrl
			};

			await _repo.AddAsync(auction);
			await _repo.SaveChangesAsync();
		}

		public async Task<bool> ExistsById(int id)
		{
			return await _repo.AllReadonly<Auction>()
				.AnyAsync(a => a.Id == id);
		}

		public async Task<AuctionDetailsModel> GetAuctionDetailsById(int id)
		{
			var model = await _repo.AllReadonly<Auction>()
				.Where(a => a.Id == id)
				.Select(a => new AuctionDetailsModel
				{
					Id = a.Id,
					Make = a.Make.Name,
					Model = a.Model,
					ModelYear = a.ModelYear,
					Mileage = a.Mileage,
					ImageUrl = a.ImageUrl,
					StartDate = a.StartDate,
					EndDate = a.EndDate,
					Vin = a.Vin,
					InteriorColor = a.InteriorColor,
					ExteriorColor = a.ExteriorColor,
					EngineDetails = a.EngineDetails,
					Transmission = a.Transmission.Type,
					Drivetrain = a.Drivetrain.Type,
					Fuel = a.Fuel.Type,
					CarBody = a.CarBody.Type,
					SellerDetails = new SellerDetailsModel
					{
						Id = a.SellerId.ToString(),
						Username = a.Seller.UserName,
						Email = a.Seller.Email,
						PhoneNumber = a.Seller.PhoneNumber
					}
				}).FirstOrDefaultAsync();

			return model!;
		}
	}
}
