namespace CarAuctionSystem.Web.Controllers
{
	using System;

	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.SignalR;

	using CarAuctionSystem.Services.Data.Contracts;
	using Hubs;
	using Infrastructure.Extensions;
	using ViewModels.Bid;
	using static Common.NotificationConstants;

	public class BidController : Controller
	{
		private readonly IAuctionService _auctionService;
		private readonly IValidationService _validationService;
		private readonly IUserService _userService;
		private readonly IHubContext<AuctionHub> _auctionHub;

		public BidController(IAuctionService auctionService,
			IValidationService validationService,
			IUserService userService,
			IHubContext<AuctionHub> auctionHub)
		{
			_auctionService = auctionService;
			_validationService = validationService;
			_userService = userService;
			_auctionHub = auctionHub;
		}

		[HttpGet]
		public async Task<IActionResult> Bid(int id, string extraInfo)
		{
			if (await _auctionService.ExistsById(id) == false)
			{
				TempData[ErrorMessage] = "Auction doesn't exist.";
				return RedirectToAction("All", "Auction");
			}

			string? sellerId = await _userService.GetSellerIdByAuctionId(id);

			if (User.Id() == sellerId)
			{
				TempData[ErrorMessage] = "Cannot bid on your own auction.";
				return RedirectToAction("All", "Auction");
			}

			if (await _auctionService.AuctionIsApproved(id) == false)
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

			var viewModel = await _auctionService.GetAuctionViewModel(id);

			if (viewModel.GetExtraInfo() != extraInfo)
			{
				TempData[ErrorMessage] = "Auction doesnt exist.";
				return RedirectToAction("Details", "Auction", new{ id = viewModel.Id, extraInfo = viewModel.GetExtraInfo() });
			}

			var model = new BidWrapperModel
			{
				Auction = await _auctionService.GetAuctionViewModel(id),
				Bids = await _auctionService.GetAllBids(id),
				BidFormModel = new BidFormModel
				{
					AuctionId = id
				}
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Bid(BidFormModel model)
		{
			if (!await _validationService.BidIsValid(model.AuctionId, model.BidAmount, User.Id()))
			{
				ModelState.AddModelError(nameof(model.BidAmount), "Bid is invalid.");
			}

			var viewModel = await _auctionService.GetAuctionViewModel(model.AuctionId);

			if (!ModelState.IsValid)
			{
				TempData[ErrorMessage] = "Bid is invalid.";
				return RedirectToAction(nameof(Bid),
					new { id = model.AuctionId, extraInfo = viewModel.GetExtraInfo() });
			}

			await _auctionService.PlaceBid(model, User.Id());

			await _auctionHub.Clients.All.SendAsync("ReceiveBid", DateTime.UtcNow.ToString(), User.Id(), User.Identity.Name, model.BidAmount.ToString("C"));

			TempData[SuccessMessage] = "Bid placed successfully.";

			return RedirectToAction("Details", "Auction",
				new { id = model.AuctionId, extraInfo = viewModel.GetExtraInfo() });

			//TODO MAKE "PLACE BID" BUTTON APPEAR IN BID.JS
		}
	}
}
