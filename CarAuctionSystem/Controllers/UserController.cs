namespace CarAuctionSystem.Controllers
{
	using Core.Contracts;
	using Microsoft.AspNetCore.Mvc;

	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Profile(string auctionId)
		{
			if (await _userService.UserExists(auctionId) == false)
			{
				return BadRequest();
			}

			var user = await _userService.GetUserProfile(auctionId);

			return View(user);
		}
	}
}
