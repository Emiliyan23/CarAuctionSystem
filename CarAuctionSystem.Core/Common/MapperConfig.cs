namespace CarAuctionSystem.Core.Common
{
	using AutoMapper;

	using Infrastructure.Data.Models;
	using Microsoft.AspNetCore.Routing.Constraints;
	using Models.Auction;

	public class MapperConfig 
	{
		public static Mapper InitializeMapper()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Auction, AllAuctionModel>();
				cfg.CreateMap<Auction, AuctionDetailsModel>()
					.ForMember(dest => dest.SellerDetails, opt => opt.Ignore());

				cfg.CreateMap<AddAuctionModel, Auction>()
					.ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.UtcNow))
					.ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => DateTime.UtcNow.AddDays(src.AuctionDuration)))
					.ForMember(dest => dest.SellerId, opt => opt.Ignore());

				cfg.CreateMap<Drivetrain, string>().ConvertUsing(d => d.Type);
				cfg.CreateMap<Transmission, string>().ConvertUsing(t => t.Type);
				cfg.CreateMap<Fuel, string>().ConvertUsing(f => f.Type);
				cfg.CreateMap<CarBody, string>().ConvertUsing(cb => cb.Type);
			});

			Mapper mapper = new Mapper(config);
			return mapper;
		}
	}
}
