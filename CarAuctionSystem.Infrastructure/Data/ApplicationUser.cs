namespace CarAuctionSystem.Infrastructure.Data
{
    using Models;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			Auctions = new List<Auction>();
			Bids = new List<Bid>();
		}

		public List<Auction> Auctions { get; set; }

		public List<Bid> Bids { get; set; }
	}
}
