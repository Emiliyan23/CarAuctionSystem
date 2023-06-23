namespace CarAuctionSystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static Constants.EntityConstants;

	public class Make
	{
		public Make()
		{
			Auctions = new List<Auction>();
		}

		[Key] public int Id { get; set; }

		[Required] [MaxLength(MakeMaxLength)] public string Name { get; set; } = null!;

		public List<Auction> Auctions { get; set; }
	}
}
