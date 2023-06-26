namespace CarAuctionSystem.Core.Models.Auction
{
	using System.ComponentModel.DataAnnotations;

	using static Infrastructure.Data.Constants.ValidationConstants;

	public class AddAuctionModel
	{
		[Required(AllowEmptyStrings = false)]
		[StringLength(AuctionModelMaxLength, MinimumLength = 1)]
		public string Model { get; set; } = null!;

		[Required]
		[Display(Name = "Auction duration")]
		public int AuctionDuration { get; set; }

		[Required]
		[Range(0, int.MaxValue)]
		[Display(Name = "Model year")]
		public int ModelYear { get; set; }

		[Required(AllowEmptyStrings = false)]
		[StringLength(AuctionVinMaxLength, MinimumLength = AuctionVinMaxLength)]
		public string Vin { get; set; } = null!;

		[Required]
		[Range(0, int.MaxValue)]
		public int Mileage { get; set; }

		[Display(Name = "Interior color")]
		[Required(AllowEmptyStrings = false)]
		[StringLength(AuctionInteriorColorMaxLength, MinimumLength = 1)]
		public string InteriorColor { get; set; } = null!;

		[Display(Name = "Exterior color")]
		[Required(AllowEmptyStrings = false)]
		[StringLength(AuctionExteriorColorMaxLength, MinimumLength = 1)]
		public string ExteriorColor { get; set; } = null!;

		[Display(Name = "Engine information")]
		[Required(AllowEmptyStrings = false)]
		[StringLength(AuctionEngineDetailsMaxLength, MinimumLength = 1)]
		public string EngineDetails { get; set; } = null!;

		[Display(Name = "Image URL")]
		[Required(AllowEmptyStrings = false)]
		[StringLength(AuctionImageUrlMaxLength, MinimumLength = 1)]
		public string ImageUrl { get; set; } = null!;

		[Display(Name = "Make")]
		public int MakeId { get; set; }

		[Display(Name = "Drivetrain")]
		public int DrivetrainId { get; set; }

		[Display(Name = "Fuel")]
		public int FuelId { get; set; }

		[Display(Name = "Transmission")]
		public int TransmissionId { get; set; }

		[Display(Name = "Car body type")]
		public int CarBodyId { get; set; }

		public IEnumerable<AuctionMakeModel> Makes { get; set; } = new List<AuctionMakeModel>();

		public IEnumerable<AuctionDrivetrainModel> Drivetrains { get; set; } = new List<AuctionDrivetrainModel>();

		public IEnumerable<AuctionFuelModel> Fuels { get; set; } = new List<AuctionFuelModel>();

		public IEnumerable<AuctionTransmissionModel> Transmissions { get; set; } = new List<AuctionTransmissionModel>();

		public IEnumerable<AuctionCarBodyModel> CarBodies { get; set; } = new List<AuctionCarBodyModel>();
	}
}
