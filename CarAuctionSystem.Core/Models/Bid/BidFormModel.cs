namespace CarAuctionSystem.Core.Models.Bid
{
	using System.ComponentModel.DataAnnotations;

	public class BidFormModel
	{
		[Required]
		public int AuctionId { get; set; }

		[Required]
		[Display(Name = "Bid Amount")]
		[Range(0, int.MaxValue)]
		public decimal BidAmount { get; set; }

		[Required]
		public DateTime BidDate { get; set; }
	}
}
