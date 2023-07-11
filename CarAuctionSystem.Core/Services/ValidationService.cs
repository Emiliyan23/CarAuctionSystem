namespace CarAuctionSystem.Core.Services
{
	using Microsoft.EntityFrameworkCore;

	using CarAuctionSystem.Infrastructure.Data.Models;
	using Contracts;
	using Infrastructure.Data.Common;

	public class ValidationService : IValidationService
	{
		private readonly IRepository _repo;

		public ValidationService(IRepository repo)
		{
			_repo = repo;
		}

		public async Task<bool> MakeExists(int id)
		{
			return await _repo.AllReadonly<Make>()
				.AnyAsync(m => m.Id == id);
		}

		public async Task<bool> DrivetrainExists(int id)
		{
			return await _repo.AllReadonly<Drivetrain>()
				.AnyAsync(d => d.Id == id);
		}

		public async Task<bool> FuelExists(int id)
		{
			return await _repo.AllReadonly<Fuel>()
				.AnyAsync(f => f.Id == id);
		}

		public async Task<bool> TransmissonExists(int id)
		{
			return await _repo.AllReadonly<Transmission>()
				.AnyAsync(t => t.Id == id);
		}

		public async Task<bool> CarBodyExists(int id)
		{
			return await _repo.AllReadonly<CarBody>()
				.AnyAsync(b => b.Id == id);
		}

		public async Task<bool> BidAmountIsValid(int auctionId, decimal bidAmount)
		{
			var auction = await _repo.AllReadonly<Auction>()
				.Where(a => a.Id == auctionId)
				.Include(a => a.Bids)
				.FirstOrDefaultAsync();

			if (auction.Bids.Any(b => b.BidAmount > bidAmount))
			{
				return false;
			}

			return true;
		}

		public async Task<bool> AuctionIsActive(int id)
		{
			var auction = await _repo.AllReadonly<Auction>()
				.Where(a => a.Id == id)
				.FirstOrDefaultAsync();

			if (auction.EndDate < DateTime.UtcNow)
			{
				return false;
			}

			return true;
		}
	}
}
