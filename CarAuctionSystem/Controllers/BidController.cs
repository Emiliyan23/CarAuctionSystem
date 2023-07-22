namespace CarAuctionSystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;
	using Core.Models.Bid;
	using Extensions;

	using static Core.Constants.NotificationConstants;

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
			string? sellerId = await _userService.GetSellerIdByAuctionId(id);

			if (User.Id() == sellerId)
			{
				TempData[ErrorMessage] = "Cannot bid on your own auction.";
				return RedirectToAction("All", "Auction");
			}

			if (await _auctionService.ExistsById(id) == false)
			{
				TempData[ErrorMessage] = "Auction doesn't exist.";
				return RedirectToAction("All", "Auction");
			}

			if (!await _validationService.AuctionIsActive(id))
			{
				TempData[ErrorMessage] = "This auction is closed.";
				return RedirectToAction("All", "Auction");
			}

			if (string.IsNullOrEmpty(sellerId))
			{
				TempData[ErrorMessage] = "Error while placing bid.";
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

			TempData[SuccessMessage] = "Bid placed successfully.";
			return RedirectToAction("Details", "Auction", new{ id = model.AuctionId });
		}
	}
}
