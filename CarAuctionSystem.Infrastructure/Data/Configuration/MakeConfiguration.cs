namespace CarAuctionSystem.Infrastructure.Data.Configuration
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	internal class MakeConfiguration : IEntityTypeConfiguration<Make>
	{
		public void Configure(EntityTypeBuilder<Make> builder)
		{
			builder.HasData(CreateMakes());
		}

		private List<Make> CreateMakes()
		{
			List<Make> makeList = new List<Make>
			{
				new Make { Id = 1, Name = "Acura" },
				new Make { Id = 2, Name = "Alfa Romeo" },
				new Make { Id = 3, Name = "Aston Martin" },
				new Make { Id = 4, Name = "Audi" },
				new Make { Id = 5, Name = "BMW" },
				new Make { Id = 6, Name = "Bentley" },
				new Make { Id = 7, Name = "Buick" },
				new Make { Id = 8, Name = "Cadillac" },
				new Make { Id = 9, Name = "Chevrolet" },
				new Make { Id = 10, Name = "Chrysler" },
				new Make { Id = 11, Name = "Dodge" },
				new Make { Id = 12, Name = "Ferrari" },
				new Make { Id = 13, Name = "Fiat" },
				new Make { Id = 14, Name = "Ford" },
				new Make { Id = 15, Name = "Honda" },
				new Make { Id = 16, Name = "Hummer" },
				new Make { Id = 17, Name = "Hyundai" },
				new Make { Id = 18, Name = "Infiniti" },
				new Make { Id = 19, Name = "Jaguar" },
				new Make { Id = 20, Name = "Jeep" },
				new Make { Id = 21, Name = "KIA" },
				new Make { Id = 22, Name = "Koenigsegg" },
				new Make { Id = 23, Name = "Lamborghini" },
				new Make { Id = 24, Name = "Land Rover" },
				new Make { Id = 25, Name = "Lexus" },
				new Make { Id = 26, Name = "Lincoln" },
				new Make { Id = 27, Name = "Lotus" },
				new Make { Id = 28, Name = "Maserati" },
				new Make { Id = 29, Name = "Maybach" },
				new Make { Id = 30, Name = "Mazda" },
				new Make { Id = 31, Name = "McLaren" },
				new Make { Id = 32, Name = "Mercedes-Benz" },
				new Make { Id = 33, Name = "Mini" },
				new Make { Id = 34, Name = "Mitsubishi" },
				new Make { Id = 35, Name = "Nissan" },
				new Make { Id = 36, Name = "Opel" },
				new Make { Id = 37, Name = "Peugeot" },
				new Make { Id = 38, Name = "Porsche" },
				new Make { Id = 39, Name = "Range Rover" },
				new Make { Id = 40, Name = "Renault" },
				new Make { Id = 41, Name = "Rolls Royce" },
				new Make { Id = 42, Name = "Saleen" },
				new Make { Id = 43, Name = "Smart" },
				new Make { Id = 44, Name = "Subaru" },
				new Make { Id = 45, Name = "Suzuki" },
				new Make { Id = 46, Name = "Tesla" },
				new Make { Id = 47, Name = "Toyota" },
				new Make { Id = 48, Name = "Volkswagen" },
				new Make { Id = 49, Name = "Volvo" }
			};

			return makeList;
		}
	}
}
