namespace CarAuctionSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Constants.ValidationConstants;

    public class Drivetrain
    {
        public Drivetrain()
        {
            Auctions = new List<Auction>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DrivetrainTypeMaxLength)]
        public string Type { get; set; } = null!;

        public List<Auction> Auctions { get; set; }
    }
}
