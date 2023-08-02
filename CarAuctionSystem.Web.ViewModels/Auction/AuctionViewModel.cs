namespace CarAuctionSystem.Web.ViewModels.Auction
{
	public class AuctionViewModel : IAuctionModel
	{
		public int Id { get; set; }

		public string Make { get; set; } = null!;

		public string Model { get; set; } = null!;

		public int ModelYear { get; set; }

		public int Mileage { get; set; }

		public string ImageUrl { get; set; } = null!;

		public DateTime EndDate { get; set; }
	}
}
