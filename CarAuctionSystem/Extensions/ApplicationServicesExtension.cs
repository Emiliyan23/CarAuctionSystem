// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
	using CarAuctionSystem.Core.Contracts;
	using CarAuctionSystem.Core.Services;
	using CarAuctionSystem.Infrastructure.Data.Common;

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
