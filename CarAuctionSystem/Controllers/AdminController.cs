﻿namespace CarAuctionSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Contracts;

	using static Common.GeneralConstants;
	using static Common.NotificationConstants;

	[Authorize(Roles = AdminRoleName)]
	public class AdminController : Controller
	{
		private readonly IAuctionService _auctionService;

		public AdminController(IAuctionService auctionService)
		{
			_auctionService = auctionService;
		}

		[Authorize(Roles = AdminRoleName)]
		[HttpGet]
		public async Task<IActionResult> AllPendingAuctions()
		{
			var auctions = await _auctionService.GetAllPendingAuctions();

			return View(auctions);
		}

		[Authorize(Roles = AdminRoleName)]
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

		[Authorize(Roles = AdminRoleName)]
		[HttpPost]
		public async Task<IActionResult> Approve(int id)
		{
			await _auctionService.ApproveAuction(id);

			TempData[SuccessMessage] = "Auction approved successfully.";
			return RedirectToAction(nameof(AllPendingAuctions));
		}
	}
}