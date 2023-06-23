namespace CarAuctionSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Constants.EntityConstants;

    public class Fuel
    {
        public Fuel()
        {
            Auctions = new List<Auction>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(FuelTypeMaxLength)]
        public string Type { get; set; } = null!;

        public List<Auction> Auctions { get; set; }
    }
}
