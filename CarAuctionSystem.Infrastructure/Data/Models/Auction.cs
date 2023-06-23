namespace CarAuctionSystem.Infrastructure.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using static Constants.EntityConstants;

    public class Auction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        //[Required]
        public Guid? SellerId { get; set; }

        [ForeignKey(nameof(SellerId))]
        public ApplicationUser? Seller { get; set; }

        [Required]
        public int MakeId { get; set; }

        [ForeignKey(nameof(MakeId))]
        public Make Make { get; set; } = null!;

        [Required]
        [MaxLength(AuctionModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        public int ModelYear { get; set; }

        [Required]
        [MaxLength(AuctionVinMaxLength)]
        public string Vin { get; set; } = null!;

        [Required]
        public int Mileage { get; set; }

        [Required]
        [MaxLength(AuctionInteriorColorMaxLength)]
        public string InteriorColor { get; set; } = null!;

        [Required]
        [MaxLength(AuctionExteriorColorMaxLength)]
        public string ExteriorColor { get; set; } = null!;

        [Required]
        [MaxLength(AuctionEngineDetailsMaxLength)]
        public string EngineDetails { get; set; } = null!;

        [Required]
        public int DrivetrainId { get; set; }

        [ForeignKey(nameof(DrivetrainId))]
        public Drivetrain Drivetrain { get; set; } = null!;

        [Required]
        public int TransmissionId { get; set; }

        [ForeignKey(nameof(TransmissionId))]
        public Transmission Transmission { get; set; } = null!;

        [Required]
        public int FuelId { get; set; }

        [ForeignKey(nameof(FuelId))]
        public Fuel Fuel { get; set; } = null!;

        [Required]
        public int CarBodyId { get; set; }

        [ForeignKey(nameof(CarBodyId))]
        public CarBody CarBody { get; set; } = null!;
    }
}
