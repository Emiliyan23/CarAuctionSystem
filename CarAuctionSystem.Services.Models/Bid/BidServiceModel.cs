namespace CarAuctionSystem.Services.Models.Bid
{
	using Contracts;

	public class BidServiceModel : IAuctionModel
	{
		public string BidderId { get; set; } = null!;

		public string BidderUsername { get; set; } = null!;

		public decimal BidAmount { get; set; }

		public DateTime BidTime { get; set; }

		public int AuctionId { get; set; }

		public int ModelYear { get; set; }

		public string Make { get; set; } = null!;

		public string Model { get; set; } = null!;
	}
}
