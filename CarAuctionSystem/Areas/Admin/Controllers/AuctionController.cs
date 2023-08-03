namespace CarAuctionSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Contracts;

	using static Common.NotificationConstants;

	public class AuctionController : BaseAdminController
	{
		private readonly IAuctionService _auctionService;

		public AuctionController(IAuctionService auctionService)
		{
			_auctionService = auctionService;
		}

		[HttpGet]
		public async Task<IActionResult> AllPendingAuctions()
		{
			var auctions = await _auctionService.GetAllPendingAuctions();

			return View(auctions);
		}

		[HttpGet]
		public async Task<IActionResult> PendingAuctionDetails(int id)
		{
			if (await _auctionService.ExistsById(id) == false)
			{
				TempData[ErrorMessage] = "Auction doesnt exist.";
				return RedirectToAction(nameof(AllPendingAuctions));
			}

			var model = await _auctionService.GetPendingAuctionDetailsById(id);

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Approve(int id)
		{
			await _auctionService.ApproveAuction(id);

			TempData[SuccessMessage] = "Auction approved successfully.";
			return RedirectToAction(nameof(AllPendingAuctions));
		}
	}
}
