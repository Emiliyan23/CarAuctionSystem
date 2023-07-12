namespace CarAuctionSystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class WatchedAuction
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public int AuctionId { get; set; }

		[ForeignKey(nameof(AuctionId))] 
		public Auction Auction { get; set; } = null!;

		[Required]
		public Guid UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public ApplicationUser User { get; set; } = null!;
	}
}
