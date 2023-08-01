namespace CarAuctionSystem.Web.ViewModels.Auction
{
	public class PendingAuctionDetailsModel : PendingAuctionModel
	{
		

		public string Vin { get; set; } = null!;

		public int Mileage { get; set; }

		public string InteriorColor { get; set; } = null!;

		public string ExteriorColor { get; set; } = null!;

		public string EngineDetails { get; set; } = null!;

		public string DrivetrainType { get; set; } = null!;

		public string TransmissionType { get; set; } = null!;

		public string FuelType { get; set; } = null!;

		public string CarBodyType { get; set; } = null!;

		public int AuctionDuration { get; set; }
	}
}
