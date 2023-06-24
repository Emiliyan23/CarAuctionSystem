using Microsoft.AspNetCore.Mvc;

namespace CarAuctionSystem.Controllers
{
	public class BidController : Controller
	{
		public IActionResult Bid()
		{
			return View();
		}
	}
}
