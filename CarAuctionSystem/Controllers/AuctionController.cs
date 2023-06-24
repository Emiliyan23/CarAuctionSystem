namespace CarAuctionSystem.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;

	[Authorize]
	public class AuctionController : Controller
	{
		private readonly IAuctionService _auctionService;

		public AuctionController(IAuctionService auctionService)
		{
			_auctionService = auctionService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> All()
		{
			var models = await _auctionService.GetAllAuctions();

			return View(models);
		}
	}
}
