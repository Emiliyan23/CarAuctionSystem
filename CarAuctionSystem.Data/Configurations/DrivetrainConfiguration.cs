namespace CarAuctionSystem.Data.Configurations
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	using Models;

	internal class DrivetrainConfiguration : IEntityTypeConfiguration<Drivetrain>
	{
		public void Configure(EntityTypeBuilder<Drivetrain> builder)
		{
			List<Drivetrain> drivetrainList = new List<Drivetrain>
			{
				new Drivetrain { Id = 1, Type = "Front-wheel drive" },
				new Drivetrain { Id = 2, Type = "Rear-wheel drive" },
				new Drivetrain { Id = 3, Type = "4WD/AWD" }
			};

			builder.HasData(drivetrainList);
		}
	}
}
