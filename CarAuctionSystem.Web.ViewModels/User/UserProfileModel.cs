namespace CarAuctionSystem.Web.ViewModels.User
{
	using Auction;

	public class UserProfileModel
	{
		public string UserId { get; set; } = null!;

		public string Username { get; set; } = null!;

		public List<AuctionViewModel> Auctions { get; set; } = new List<AuctionViewModel>();

		public List<UserBidModel> Bids { get; set; } = new List<UserBidModel>();
	}
}
