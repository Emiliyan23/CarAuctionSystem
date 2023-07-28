// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
	using CarAuctionSystem.Data.Repositories;
	using CarAuctionSystem.Services.Data;
	using CarAuctionSystem.Services.Data.Contracts;

	public static class ApplicationServicesExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IRepository, Repository>();
			services.AddScoped<IAuctionService, AuctionService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ICarService, CarService>();
			services.AddScoped<IValidationService, ValidationService>();

			return services;
		}
	}
}
