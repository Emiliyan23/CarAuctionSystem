namespace CarAuctionSystem.Data
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	using Configurations;
	using Models;

	public class CarAuctionDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
	{
		public CarAuctionDbContext(DbContextOptions<CarAuctionDbContext> options)
			: base(options)
		{
		}

		public DbSet<Auction> Auctions { get; set; } = null!;

		public DbSet<Bid> Bids { get; set; } = null!;

		public DbSet<Make> Makes { get; set; } = null!;

		public DbSet<Drivetrain> Drivetrains { get; set; } = null!;

		public DbSet<Fuel> Fuels { get; set; } = null!;

		public DbSet<Transmission> Transmissions { get; set; } = null!;

		public DbSet<CarBody> CarBodies { get; set; } = null!;

		public DbSet<WatchedAuction> WatchedAuctions { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//builder.ApplyConfiguration(new UserConfiguration());
			builder.ApplyConfiguration(new CarBodyConfiguration());
			builder.ApplyConfiguration(new DrivetrainConfiguration());
			builder.ApplyConfiguration(new FuelConfiguration());
			builder.ApplyConfiguration(new MakeConfiguration());
			builder.ApplyConfiguration(new TransmissionConfiguration());
			//builder.ApplyConfiguration(new AuctionConfiguration());

			builder.Entity<Bid>(entity =>
			{
				entity.HasOne(b => b.Auction)
					.WithMany(a => a.Bids)
					.HasForeignKey(b => b.AuctionId)
					.OnDelete(DeleteBehavior.NoAction);

				entity.HasOne(b => b.Bidder)
					.WithMany(user => user.Bids)
					.HasForeignKey(b => b.BidderId)
					.OnDelete(DeleteBehavior.Restrict);
			});

			builder.Entity<WatchedAuction>(entity =>
			{
				entity.HasOne(wa => wa.Auction)
					.WithMany(u => u.Watchlist)
					.HasForeignKey(wa => wa.AuctionId)
					.OnDelete(DeleteBehavior.NoAction);
			});

			base.OnModelCreating(builder);
		}
	}
}