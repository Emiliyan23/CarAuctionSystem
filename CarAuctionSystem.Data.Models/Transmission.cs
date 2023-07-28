namespace CarAuctionSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;

	using static Common.EntityConstants;

	public class Transmission
    {
        public Transmission()
        {
            Auctions = new List<Auction>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TransmissionTypeMaxLength)]
        public string Type { get; set; } = null!;

        public List<Auction> Auctions { get; set; }
    }
}
