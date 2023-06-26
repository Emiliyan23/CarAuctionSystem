﻿namespace CarAuctionSystem.Controllers
{
	using System.Diagnostics;
	using Infrastructure.Data.Models;
	using Microsoft.AspNetCore.Mvc;

	using Models;

	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{ 
			return RedirectToAction(nameof(AuctionController.All), nameof(Auction));
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}