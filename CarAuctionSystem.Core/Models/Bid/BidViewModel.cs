﻿namespace CarAuctionSystem.Core.Models.Bid
{
	public class BidViewModel
	{
		public DateTime BidDate { get; set; }

		public string BidderUsername { get; set; } = null!;

		public decimal BidAmount { get; set; }
	}
}
