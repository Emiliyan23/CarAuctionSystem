namespace CarAuctionSystem.Core.Models.User
{
	using Bid;

	public class UserBidModel : BidViewModel
	{
		public int AuctionId { get; set; }

		public string Make { get; set; } = null!;

		public string Model { get; set; } = null!;
	}
}
