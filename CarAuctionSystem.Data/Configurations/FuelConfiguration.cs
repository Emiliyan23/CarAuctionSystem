namespace CarAuctionSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	internal class FuelConfiguration : IEntityTypeConfiguration<Fuel>
	{
		public void Configure(EntityTypeBuilder<Fuel> builder)
		{
			List<Fuel> fuelList = new List<Fuel>
			{
				new Fuel { Id = 1, Type = "Petrol" },
				new Fuel { Id = 2, Type = "Diesel" },
				new Fuel { Id = 3, Type = "Hybrid" },
				new Fuel { Id = 4, Type = "EV" }
			};

			builder.HasData(fuelList);
		}
	}
}
