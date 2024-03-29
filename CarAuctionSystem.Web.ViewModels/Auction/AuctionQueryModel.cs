﻿namespace CarAuctionSystem.Web.ViewModels.Auction
{
	public class AuctionQueryModel
	{
		public int TotalAuctions { get; set; }

		public IEnumerable<AuctionViewModel> Auctions { get; set; } = new List<AuctionViewModel>();
	}
}
