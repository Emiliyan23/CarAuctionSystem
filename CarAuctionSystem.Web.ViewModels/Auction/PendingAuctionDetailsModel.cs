namespace CarAuctionSystem.Web.ViewModels.Auction
{
	using Seller;

	public class PendingAuctionDetailsModel : AuctionViewModel
    {


        public string Vin { get; set; } = null!;

        public string InteriorColor { get; set; } = null!;

        public string ExteriorColor { get; set; } = null!;

        public string EngineDetails { get; set; } = null!;

        public string DrivetrainType { get; set; } = null!;

        public string TransmissionType { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        public string CarBodyType { get; set; } = null!;

        public int AuctionDuration { get; set; }

        public SellerDetailsModel SellerDetails { get; set; } = null!;

    }
}
