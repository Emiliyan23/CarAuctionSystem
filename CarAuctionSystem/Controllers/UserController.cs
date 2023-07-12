namespace CarAuctionSystem.Controllers
{
	using Core.Contracts;
	using Extensions;
	using Microsoft.AspNetCore.Mvc;

	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public async Task<IActionResult> Profile(string id)
		{
			if (await _userService.UserExists(id) == false)
			{
				return BadRequest();
			}

			var user = await _userService.GetUserProfile(id);

			return View(user);
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
	}
}
