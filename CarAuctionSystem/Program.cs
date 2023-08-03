using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using CarAuctionSystem.Data;
using CarAuctionSystem.Data.Models;
using CarAuctionSystem.Web.Infrastructure.Extensions;
using CarAuctionSystem.Web.Infrastructure.ModelBinders;

using static CarAuctionSystem.Common.GeneralConstants;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<CarAuctionDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
	{
		options.SignIn.RequireConfirmedAccount = false;
		options.Password.RequireDigit = false;
		options.Password.RequireUppercase = false;
		options.Password.RequireNonAlphanumeric = false;
		options.Password.RequiredLength = 5;
		options.Password.RequiredUniqueChars = 0;
	})
	.AddRoles<IdentityRole<Guid>>()
	.AddEntityFrameworkStores<CarAuctionDbContext>();

builder.Services.AddControllersWithViews()
	.AddMvcOptions(options =>
	{
		options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
	});

builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Home/Error/500");
	app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
	app.SeedAdministrator(DevelopmentAdminEmail);

}

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "Areas",
		pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

	endpoints.MapControllerRoute(
		name: "AuctionDetailsWithExtraInfo",
		pattern: "{controller=Auction}/{action=Details}/{id}/{extraInfo}",
		defaults: new { controller = "Auction", action = "Details" });

	endpoints.MapControllerRoute(
		name: "BidWithExtraInfo",
		pattern: "{controller=Bid}/{action=Bid}/{id}/{extraInfo}",
		defaults: new { controller = "Bid", action = "Bid" });

	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
	endpoints.MapRazorPages();
});

app.Run();