namespace CarAuctionSystem.Core.Models.Auction
{
	public class PendingAuctionModel
	{
		public int Id { get; set; }

		public string Make { get; set; } = null!;

		public string Model { get; set; } = null!;

		public int ModelYear { get; set; }
	}
}
