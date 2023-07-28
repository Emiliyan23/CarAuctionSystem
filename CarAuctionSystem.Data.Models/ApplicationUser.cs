namespace CarAuctionSystem.Data.Models
{
	using Microsoft.AspNetCore.Identity;

	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			Auctions = new List<Auction>();
			Bids = new List<Bid>();
			Watchlist = new List<WatchedAuction>();
		}

		public List<Auction> Auctions { get; set; }

		public List<Bid> Bids { get; set; }

		public List<WatchedAuction> Watchlist { get; set; }
	}
}
