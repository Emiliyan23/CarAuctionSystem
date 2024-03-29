﻿namespace CarAuctionSystem.Web.ViewModels.User
{
	using Bid;
	using Services.Models.Contracts;

	public class UserBidModel : BidViewModel, IAuctionModel
	{
		public int AuctionId { get; set; }

		public int ModelYear { get; set; }

		public string Make { get; set; } = null!;

		public string Model { get; set; } = null!;
	}
}
