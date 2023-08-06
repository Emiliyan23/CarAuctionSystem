using Microsoft.AspNetCore.Mvc;

namespace CarAuctionSystem.Web.Areas.Admin.Controllers
{
    using Services.Data.Contracts;

    public class UserController : BaseAdminController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            var allUsers = await _userService.All();

            return View(allUsers);
        }
    }
}
