namespace CarAuctionSystem.Infrastructure.Data
{
    using Models;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			Auctions = new List<Auction>();
		}

		public List<Auction> Auctions { get; set; }
	}
}
