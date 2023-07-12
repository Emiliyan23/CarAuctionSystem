namespace CarAuctionSystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;
	using Core.Models.Bid;
	using Extensions;

	public class BidController : Controller
	{
		private readonly IAuctionService _auctionService;
		private readonly IValidationService _validationService;
		private readonly IUserService _userService;

		public BidController(IAuctionService auctionService, IValidationService validationService, IUserService userService)
		{
			_auctionService = auctionService;
			_validationService = validationService;
			_userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> Bid(int id)
		{
			if (!await _validationService.AuctionIsActive(id))
			{
				return RedirectToAction("All", "Auction");
			}

			string? sellerId = await _userService.GetSellerIdByAuctionId(id);

			if (string.IsNullOrEmpty(sellerId))
			{
				return RedirectToAction("All", "Auction");
			}

			if (User.Id() == sellerId)
			{
				return RedirectToAction("All", "Auction");
			}

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

			return RedirectToAction("Details", "Auction", model.AuctionId);
		}
	}
}
