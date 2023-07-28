namespace CarAuctionSystem.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using CarAuctionSystem.Services.Data.Contracts;
	using Infrastructure.Extensions;

	[Authorize]
	public class UserController : Controller
	{
		private readonly IUserService _userService;
		private readonly IAuctionService _auctionService;

		public UserController(IUserService userService, IAuctionService auctionService)
		{
			_userService = userService;
			_auctionService = auctionService;
		}

		[AllowAnonymous]
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
		public async Task<IActionResult> MyPendingAuctions()
		{
			var auctions = await _auctionService.GetAllPendingAuctionsByUserId(User.Id());

			return View(auctions);
		}

	}
}
