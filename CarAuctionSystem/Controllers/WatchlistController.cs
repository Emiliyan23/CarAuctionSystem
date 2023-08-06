namespace CarAuctionSystem.Web.Controllers
{
	using CarAuctionSystem.Services.Data.Contracts;
	using CarAuctionSystem.Web.Infrastructure.Extensions;
	using Microsoft.AspNetCore.Mvc;

	public class WatchlistController : Controller
	{
		private readonly IAuctionService _auctionService;
		private readonly IUserService _userService;

		public WatchlistController(IAuctionService auctionService, IUserService userService)
		{
			_auctionService = auctionService;
			_userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> Watchlist()
		{
			var watchlist = await _userService.GetWatchlist(User.Id());

			return View(watchlist);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Add(int id)
		{
			string userId = User.Id();

			if (await _userService.UserExists(userId) == false)
			{
				return BadRequest();
			}

			if (await _auctionService.ExistsById(id) == false)
			{
				return BadRequest();
			}

			if (await _userService.AuctionIsInWatchlist(id, userId))
			{
				return RedirectToAction("Watchlist", "Watchlist");
			}

			await _userService.AddToWatchlist(id, userId);
			
			return Json(new { success = true });
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Remove(int id)
		{
			string userId = User.Id();

			if (await _userService.UserExists(userId) == false)
			{
				return BadRequest();
			}

			if (await _auctionService.ExistsById(id) == false)
			{
				return BadRequest();
			}

			await _userService.RemoveFromWatchlist(id, userId);
			
			return Json(new { success = true });
		}
	}
}
