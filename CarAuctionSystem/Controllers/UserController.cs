﻿namespace CarAuctionSystem.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;

	[Authorize]
	public class UserController : Controller
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
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

	}
}
