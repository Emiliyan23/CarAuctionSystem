namespace CarAuctionSystem.Infrastructure.Data
{
	using Microsoft.AspNetCore.Identity;

    using Models;

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
