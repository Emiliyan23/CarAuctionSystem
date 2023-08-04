namespace CarAuctionSystem.Data.Models
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

    using static Common.EntityConstants;
	public class Auction
    {
	    public Auction()
	    {
		    Bids = new List<Bid>();
		    Watchlist = new List<WatchedAuction>();
	    }

        [Key]
        public int Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public Guid SellerId { get; set; }

        [ForeignKey(nameof(SellerId))] 
        public ApplicationUser Seller { get; set; } = null!;

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
        [MaxLength(AuctionImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

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

        public List<Bid> Bids { get; set; }

        public List<WatchedAuction> Watchlist { get; set; }

        [Required]
        public bool IsApproved { get; set; } = false;

        [Required]
        public int AuctionDuration { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
