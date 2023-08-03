namespace CarAuctionSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	using Services.Data.Contracts;

	public class HomeController : AdminController
	{
		public IActionResult Index()
		{
			return View();
		}

		public HomeController(IAuctionService auctionService) : base(auctionService)
		{
		}
	}
}
