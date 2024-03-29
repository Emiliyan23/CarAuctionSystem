﻿namespace CarAuctionSystem.Web.ViewModels.Auction
{
	using Bid;
	using Seller;

	public class AuctionDetailsModel : AuctionViewModel
	{
		public AuctionDetailsModel()
		{
			Bids = new List<BidViewModel>();
			Watchlist = new List<int>();
		}

		public DateTime StartDate { get; set; }

		public SellerDetailsModel SellerDetails { get; set; } = null!;

		public string Vin { get; set; } = null!;

		public string InteriorColor { get; set; } = null!;

		public string ExteriorColor { get; set; } = null!;

		public string EngineDetails { get; set; } = null!;

		public string Drivetrain { get; set; } = null!;

		public string Transmission { get; set; } = null!;

		public string Fuel { get; set; } = null!;

		public string CarBody { get; set; } = null!;

		public List<int> Watchlist { get; set; }

		public List<BidViewModel> Bids { get; set; }
	}
}
