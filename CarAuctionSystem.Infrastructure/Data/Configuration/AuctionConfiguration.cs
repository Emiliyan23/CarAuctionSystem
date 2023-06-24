namespace CarAuctionSystem.Infrastructure.Data.Configuration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	internal class AuctionConfiguration : IEntityTypeConfiguration<Auction>
	{
		public void Configure(EntityTypeBuilder<Auction> builder)
		{
			builder.HasData(CreateAuctions());
		}

		private List<Auction> CreateAuctions()
		{
			List<Auction> auctionList = new List<Auction>
			{
				new Auction
				{
					Id = 1,
					MakeId = 32,
					Model = "C270 CDI",
					CarBodyId = 4,
					DrivetrainId = 2,
					FuelId = 2,
					TransmissionId = 2,
					StartDate = DateTime.UtcNow,
					EndDate = DateTime.UtcNow.AddDays(3),
					ModelYear = 2004,
					Vin = "WDB2030161A714562",
					Mileage = 250000,
					InteriorColor = "Black/Antracite",
					ExteriorColor = "Brilliant silver metallic",
					EngineDetails = "2.7L Inline-5",
					SellerId = Guid.Parse("b1a92f4d-76ce-44a4-e11f-08db7437f7de")
				}
			};

			return auctionList;
		}
	}
}
