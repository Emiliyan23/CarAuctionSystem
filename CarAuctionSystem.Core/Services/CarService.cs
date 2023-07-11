namespace CarAuctionSystem.Core.Services
{
	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Models.Auction;
	using Infrastructure.Data.Common;
	using Infrastructure.Data.Models;

	public class CarService : ICarService
	{
		private readonly IRepository _repo;

		public CarService(IRepository repo)
		{
			_repo = repo;
		}

		public async Task<IEnumerable<AuctionMakeModel>> GetAllMakes()
		{
			return await _repo.AllReadonly<Make>()
				.OrderBy(m => m.Name)
				.Select(m => new AuctionMakeModel
				{
					Id = m.Id,
					Name = m.Name
				}).ToListAsync();
		}

		public async Task<IEnumerable<AuctionDrivetrainModel>> GetAllDrivetrains()
		{
			return await _repo.AllReadonly<Drivetrain>()
				.OrderBy(d => d.Type)
				.Select(d => new AuctionDrivetrainModel
				{
					Id = d.Id,
					Type = d.Type
				}).ToListAsync();
		}

		public async Task<IEnumerable<AuctionTransmissionModel>> GetAllTransmissions()
		{
			return await _repo.AllReadonly<Transmission>()
				.OrderBy(t => t.Type)
				.Select(t => new AuctionTransmissionModel
				{
					Id = t.Id,
					Type = t.Type
				}).ToListAsync();
		}

		public async Task<IEnumerable<string>> GetAllTransmissionTypes()
		{
			return await _repo.AllReadonly<Transmission>()
				.OrderBy(t => t.Type)
				.Select(t => new string(t.Type))
				.ToListAsync();
		}

		public async Task<IEnumerable<AuctionFuelModel>> GetAllFuels()
		{
			return await _repo.AllReadonly<Fuel>()
				.OrderBy(f => f.Type)
				.Select(f => new AuctionFuelModel
				{
					Id = f.Id,
					Type = f.Type
				}).ToListAsync();
		}

		public async Task<IEnumerable<AuctionCarBodyModel>> GetAllCarBodies()
		{
			return await _repo.AllReadonly<CarBody>()
				.OrderBy(b => b.Type)
				.Select(b => new AuctionCarBodyModel
				{
					Id = b.Id,
					Type = b.Type
				}).ToListAsync();
		}

		public async Task<IEnumerable<string>> GetAllCarBodyTypes()
		{
			return await _repo.AllReadonly<CarBody>()
				.OrderBy(cb => cb.Type)
				.Select(cb => new string(cb.Type))
				.ToListAsync();

		}
	}
}
