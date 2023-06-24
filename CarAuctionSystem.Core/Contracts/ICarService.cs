using CarAuctionSystem.Core.Models.Auction;

namespace CarAuctionSystem.Core.Contracts
{
	public interface ICarService
	{
		Task<IEnumerable<AuctionMakeModel>> GetAllMakes();

		Task<IEnumerable<AuctionDrivetrainModel>> GetAllDrivetrains();

		Task<IEnumerable<AuctionTransmissionModel>> GetAllTransmissions();

		Task<IEnumerable<AuctionFuelModel>> GetAllFuels();

		Task<IEnumerable<AuctionCarBodyModel>> GetAllCarBodies();

		Task<bool> MakeExists(int id);

		Task<bool> DrivetrainExists(int id);

		Task<bool> FuelExists(int id);

		Task<bool> TransmissonExists(int id);

		Task<bool> CarBodyExists(int id);
	}
}
