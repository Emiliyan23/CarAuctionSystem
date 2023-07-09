namespace CarAuctionSystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;
	using Core.Models.Bid;
	using Extensions;

	public class BidController : Controller
	{
		private readonly IAuctionService _auctionService;

		public BidController(IAuctionService auctionService)
		{
			_auctionService = auctionService;
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
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			await _auctionService.PlaceBid(model, User.Id());

			return RedirectToAction("Details", "Auction", new { id = model.AuctionId });
		}
	}
}
