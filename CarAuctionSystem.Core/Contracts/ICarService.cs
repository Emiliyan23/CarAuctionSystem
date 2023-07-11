using CarAuctionSystem.Core.Models.Auction;

namespace CarAuctionSystem.Core.Contracts
{
	public interface ICarService
	{
		Task<IEnumerable<AuctionMakeModel>> GetAllMakes();

		Task<IEnumerable<AuctionDrivetrainModel>> GetAllDrivetrains();

		Task<IEnumerable<AuctionTransmissionModel>> GetAllTransmissions();

		Task<IEnumerable<string>> GetAllTransmissionTypes();

		Task<IEnumerable<AuctionFuelModel>> GetAllFuels();

		Task<IEnumerable<AuctionCarBodyModel>> GetAllCarBodies();

		Task<IEnumerable<string>> GetAllCarBodyTypes();
	}
}
