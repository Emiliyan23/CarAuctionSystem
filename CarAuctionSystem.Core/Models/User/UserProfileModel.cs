namespace CarAuctionSystem.Core.Models.User
{
	using Auction;
	using Bid;

	public class UserProfileModel
	{
		public string UserId { get; set; } = null!;

		public string Username { get; set; } = null!;

		public List<AllAuctionModel> Auctions { get; set; } = new List<AllAuctionModel>();

		public List<UserBidModel> Bids { get; set; } = new List<UserBidModel>();
	}
}
