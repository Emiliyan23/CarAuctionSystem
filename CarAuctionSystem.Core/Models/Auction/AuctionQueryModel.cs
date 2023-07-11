namespace CarAuctionSystem.Core.Models.Auction
{
	public class AuctionQueryModel
	{
		public int TotalAuctions { get; set; }

		public IEnumerable<AllAuctionModel> Auctions { get; set; } = new List<AllAuctionModel>();
	}
}
