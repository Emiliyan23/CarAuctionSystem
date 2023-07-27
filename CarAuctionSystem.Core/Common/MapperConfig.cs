namespace CarAuctionSystem.Core.Common
{
	using AutoMapper;

	using Infrastructure.Data.Models;
	using Models.Auction;
	using Models.Bid;

	public class MapperConfig 
	{
		public static Mapper InitializeMapper()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<Auction, AuctionViewModel>();
				cfg.CreateMap<Auction, AuctionDetailsModel>()
					.ForMember(dest => dest.SellerDetails, opt => opt.Ignore());

				cfg.CreateMap<AuctionFormModel, Auction>()
					.ForMember(dest => dest.StartDate, opt => opt.Ignore())
					.ForMember(dest => dest.EndDate, opt => opt.Ignore())
					.ForMember(dest => dest.SellerId, opt => opt.Ignore());

				cfg.CreateMap<Bid, BidViewModel>()
					.ForMember(dest => dest.BidderUsername, opt => opt.MapFrom(src => src.Bidder.UserName));

				cfg.CreateMap<Make, string>().ConvertUsing(m => m.Name);
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
