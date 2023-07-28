namespace CarAuctionSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	internal class CarBodyConfiguration : IEntityTypeConfiguration<CarBody>

	{
		public void Configure(EntityTypeBuilder<CarBody> builder)
		{
			builder.HasData(CreateBodies());
		}

		private List<CarBody> CreateBodies()
		{
			List<CarBody> bodyList = new List<CarBody>
			{
				new CarBody { Id = 1, Type = "Coupe" },
				new CarBody { Id = 2, Type = "Convertible" },
				new CarBody { Id = 3, Type = "Hatchback" },
				new CarBody { Id = 4, Type = "Sedan" },
				new CarBody { Id = 5, Type = "SUV/Crossover" },
				new CarBody { Id = 6, Type = "Truck" },
				new CarBody { Id = 7, Type = "Van/Minivan" },
				new CarBody { Id = 8, Type = "Wagon" },
				new CarBody { Id = 9, Type = "Other" }
			};

			return bodyList;
		}
	}
}
