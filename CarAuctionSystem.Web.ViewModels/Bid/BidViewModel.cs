namespace CarAuctionSystem.Web.ViewModels.Bid
{
	public class BidViewModel
	{
		public DateTime BidTime { get; set; }

		public string BidderId { get; set; } = null!;

		public string BidderUsername { get; set; } = null!;

		public decimal BidAmount { get; set; }
	}
}
