﻿namespace CarAuctionSystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;
	using Extensions;

	using static Core.Constants.NotificationConstants;

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
		public async Task<IActionResult> Watchlist(string id)
		{
			if (id != User.Id())
			{
				return Unauthorized();
			}

			var watchlist = await _userService.GetWatchlist(id);

			return View(watchlist);
		}

		[HttpPost]
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
