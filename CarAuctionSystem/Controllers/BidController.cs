﻿namespace CarAuctionSystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;
	using Core.Models.Bid;
	using Extensions;

	public class BidController : Controller
	{
		private readonly IAuctionService _auctionService;
		private readonly IValidationService _validationService;

		public BidController(IAuctionService auctionService, IValidationService validationService)
		{
			_auctionService = auctionService;
			_validationService = validationService;
		}

		[HttpGet]
		public async Task<IActionResult> Bid(int id)
		{
			BidFormModel bidModel = new BidFormModel
			{
				AuctionId = id
			};

			return View(bidModel);
		}

		[HttpPost]
		public async Task<IActionResult> Bid(BidFormModel model)
		{
			if (!await _validationService.BidAmountIsValid(model.AuctionId, model.BidAmount))
			{
				ModelState.AddModelError(nameof(model.BidAmount), "Bid amount is lower than latest bid.");
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _auctionService.PlaceBid(model, User.Id());

			return RedirectToAction("Details", "Auction", new { id = model.AuctionId });
		}
	}
}
