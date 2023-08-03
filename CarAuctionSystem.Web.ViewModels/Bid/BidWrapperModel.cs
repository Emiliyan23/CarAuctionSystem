namespace CarAuctionSystem.Web.ViewModels.Bid
{
	using Auction;

	public class BidWrapperModel
	{
		public BidWrapperModel()
		{
			Bids = new List<BidViewModel>();
		}

		public AuctionViewModel Auction { get; set; } = null!;

		public BidFormModel BidFormModel { get; set; } = null!;

		public List<BidViewModel> Bids { get; set; }

	}
}
