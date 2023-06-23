namespace CarAuctionSystem.Infrastructure.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static Constants.EntityConstants;

	public class CarBody
	{
		public CarBody()
		{
			Auctions = new List<Auction>();
		}

		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(CarBodyTypeMaxLength)]
		public string Type { get; set; } = null!;

		public List<Auction> Auctions { get; set; }
	}
}
