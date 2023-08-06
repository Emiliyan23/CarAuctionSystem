namespace CarAuctionSystem.Services.Models.Contracts
{
	public interface IAuctionModel
	{
		public int ModelYear { get; set; }

		public string Make { get; set; }

		public string Model { get; set; }
	}
}
