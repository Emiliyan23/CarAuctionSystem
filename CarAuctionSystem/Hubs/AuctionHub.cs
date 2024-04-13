namespace CarAuctionSystem.Web.Hubs
{
	using Microsoft.AspNetCore.SignalR;

	using Services.Data.Contracts;

	public class AuctionHub : Hub
	{
		private readonly IAuctionService _auctionService;

		public AuctionHub(IAuctionService auctionService)
		{
			_auctionService = auctionService;
		}
	}
}
