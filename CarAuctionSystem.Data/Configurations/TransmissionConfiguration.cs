namespace CarAuctionSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	internal class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
	{
		public void Configure(EntityTypeBuilder<Transmission> builder)
		{
			List<Transmission> transmissionList = new List<Transmission>
			{
				new Transmission { Id = 1, Type = "Manual" },
				new Transmission { Id = 2, Type = "Automatic" },
				new Transmission { Id = 3, Type = "EV" }
			};

			builder.HasData(transmissionList);
		}
	}
}
