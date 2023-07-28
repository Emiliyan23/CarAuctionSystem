namespace CarAuctionSystem.WebApi.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Services.Data.Contracts;
	using Services.Models.Statistics;

	[Route("api/statistics")]
	[ApiController]
	public class StatisticsApiController : ControllerBase
	{
		private readonly IAuctionService _auctionService;
		public StatisticsApiController(IAuctionService auctionService)
		{
			_auctionService = auctionService;
		}

		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(200, Type = typeof(StatisticsServiceModel))] 
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetStatistics()
		{
			try
			{
				StatisticsServiceModel serviceModel = await _auctionService.GetStatistics();
				return Ok(serviceModel);
			}
			catch (Exception)
			{
				return BadRequest();
			}
		}
	}
}
