namespace CarAuctionSystem.Web.ViewModels.Auction
{
	using Seller;

	public class PendingAuctionModel
	{
		public int Id { get; set; }

		public string Make { get; set; } = null!;

		public string Model { get; set; } = null!;

		public int ModelYear { get; set; }

		public string ImageUrl { get; set; } = null!;

		public SellerDetailsModel SellerDetails { get; set; } = null!;
	}
}
