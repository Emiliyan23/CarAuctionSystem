﻿namespace CarAuctionSystem.Infrastructure.Data
{
	using Configuration;
	using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class CarAuctionDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public CarAuctionDbContext(DbContextOptions<CarAuctionDbContext> options)
			: base(options)
		{
		}

		public DbSet<Auction> Auctions { get; set; } = null!;

		public DbSet<Make> Makes { get; set; } = null!;

		public DbSet<Drivetrain> Drivetrains { get; set; } = null!;

		public DbSet<Fuel> Fuels { get; set; } = null!;

		public DbSet<Transmission> Transmissions { get; set; } = null!;

		public DbSet<CarBody> CarBodies { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new CarBodyConfiguration());
			builder.ApplyConfiguration(new DrivetrainConfiguration());
			builder.ApplyConfiguration(new FuelConfiguration());
			builder.ApplyConfiguration(new MakeConfiguration());
			builder.ApplyConfiguration(new TransmissionConfiguration());
			builder.ApplyConfiguration(new AuctionConfiguration());

			base.OnModelCreating(builder);
		}
	}
}