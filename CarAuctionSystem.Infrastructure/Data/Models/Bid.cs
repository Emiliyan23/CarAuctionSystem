namespace CarAuctionSystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Bid
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public DateTime BidDate { get; set; }

		[Required]
		public Guid BidderId { get; set; }

		[ForeignKey(nameof(BidderId))] 
		public ApplicationUser Bidder { get; set; } = null!;

		[Required]
		public int AuctionId { get; set; }

		[ForeignKey(nameof(AuctionId))]
		public Auction Auction { get; set; } = null!;

		[Required]
		[Column(TypeName = "money")]
		public decimal BidAmount { get; set; }
	}
}
