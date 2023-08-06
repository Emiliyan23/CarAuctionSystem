namespace CarAuctionSystem.Web.Areas.Admin.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Caching.Memory;

	using Services.Data.Contracts;
	using Services.Models.User;

    using static Common.AdminConstants;

	public class UserController : BaseAdminController
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _cache;

        public UserController(IUserService userService, IMemoryCache cache)
        {
            _userService = userService;
            _cache = cache;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
	        var allUsers = _cache.Get<List<UserServiceModel>>(UsersCacheKey);

	        if (allUsers == null)
	        {
		        allUsers = await _userService.All();
		        var cacheOptions = new MemoryCacheEntryOptions()
			        .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

		        _cache.Set(UsersCacheKey, allUsers, cacheOptions);
	        }

            return View(allUsers);
        }
    }
}
