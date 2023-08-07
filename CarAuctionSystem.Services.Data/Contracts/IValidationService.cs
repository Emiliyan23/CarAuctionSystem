namespace CarAuctionSystem.Services.Data.Contracts
{
	public interface IValidationService
	{
		Task<bool> MakeExists(int id);

		Task<bool> DrivetrainExists(int id);

		Task<bool> FuelExists(int id);

		Task<bool> TransmissonExists(int id);

		Task<bool> CarBodyExists(int id);

		Task<bool> BidIsValid(int auctionId, decimal bidAmount, string userId);

		Task<bool> AuctionIsActive(int id);
	}
}
