namespace CarAuctionSystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Infrastructure.Data.Models;

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
		public IActionResult Error(int statusCode)
		{
			if (statusCode == 400 || statusCode == 404)
			{
				return View("Error404");
			}

			if (statusCode == 401)
			{
				return View("Error401");
			}

			return View();
		}
	}
}