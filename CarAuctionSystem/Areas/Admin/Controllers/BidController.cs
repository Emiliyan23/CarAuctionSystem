namespace CarAuctionSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Contracts;

	public class BidController : BaseAdminController
	{
		private readonly IBidService _bidService;

		public BidController(IBidService bidService)
		{
			_bidService = bidService;
		}

		[Route("Bid/All")]
		public async Task<IActionResult> All()
		{
			var allBids = await _bidService.All();

			return View(allBids);
		}
	}
}
