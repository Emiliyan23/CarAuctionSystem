namespace CarAuctionSystem.Infrastructure.Data.Configuration
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore.Metadata.Builders;

	internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.HasData(CreateUsers());
		}

		private List<ApplicationUser> CreateUsers()
		{
			List<ApplicationUser> users = new List<ApplicationUser>();
			var hasher = new PasswordHasher<ApplicationUser>();

			var user = new ApplicationUser
			{
				Id = Guid.NewGuid(),
				UserName = "emiliqn.slav@gmail.com",
				NormalizedUserName = "EMILIQN.SLAV@GMAIL.COM",
				Email = "emiliqn.slav@gmail.com",
				NormalizedEmail = "EMILIQN.SLAV@GMAIL.COM"
			};

			user.PasswordHash = hasher.HashPassword(user, "emiliqn");

			users.Add(user);

			return users;
		}
	}
}
