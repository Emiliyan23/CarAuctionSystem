namespace CarAuctionSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;

	using Services.Data.Contracts;

	using static Common.AdminConstants;
	using static Common.NotificationConstants;

	public class AuctionController : BaseAdminController
	{
		private readonly IAuctionService _auctionService;
		private readonly ICarService _carService;
		private readonly IMemoryCache _cache;

		public AuctionController(
			IAuctionService auctionService,
			ICarService carService,
			IMemoryCache cache)
		{
			_auctionService = auctionService;
			_carService = carService;
			_cache = cache;
		}

		[HttpGet]
		public async Task<IActionResult> AllPending()
		{
			var auctions = await _auctionService.GetAllPendingAuctions();

			return View(auctions);
		}

		[HttpGet]
		public async Task<IActionResult> PendingDetails(int id)
		{
			if (await _auctionService.ExistsById(id) == false)
			{
				TempData[ErrorMessage] = "Auction doesnt exist.";
				return RedirectToAction(nameof(AllPending));
			}

			var model = await _auctionService.GetPendingAuctionDetailsById(id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Approve(int id)
		{
			await _auctionService.ApproveAuction(id);
			_cache.Remove(UsersCacheKey);

			TempData[SuccessMessage] = "Auction approved successfully.";
			return RedirectToAction(nameof(AllPending));
		}
	}
}
