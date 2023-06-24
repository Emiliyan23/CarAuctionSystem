// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
	using CarAuctionSystem.Core.Contracts;
	using CarAuctionSystem.Core.Services;
	using CarAuctionSystem.Infrastructure.Data.Common;

	public static class CarAuctionServiceCollectionExtension
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddScoped<IRepository, Repository>();
			services.AddScoped<IAuctionService, AuctionService>();

			return services;
		}
	}
}
