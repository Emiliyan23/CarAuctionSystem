namespace CarAuctionSystem.Web.Controllers
{
    using CarAuctionSystem.Services.Data.Contracts;
    using Infrastructure.Extensions;
    using ViewModels.Auction;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static Common.NotificationConstants;

    [Authorize]
    public class AuctionController : Controller
    {
        private readonly IAuctionService _auctionService;
        private readonly IUserService _userService;
        private readonly ICarService _carService;
        private readonly IValidationService _validationService;

        public AuctionController(
            IAuctionService auctionService,
            IUserService userService,
            ICarService carService,
            IValidationService validationService)
        {
            _auctionService = auctionService;
            _userService = userService;
            _carService = carService;
            _validationService = validationService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllAuctionsQueryModel query)
        {
            if (query.StartYear < 1980 || query.EndYear < 1980)
            {
                TempData[ErrorMessage] = "Invalid search.";
                return RedirectToAction(nameof(All));
            }

            if (query.StartYear > query.EndYear)
            {
                query.EndYear = null;
                return RedirectToAction(nameof(All), query);
            }

            var result = await _auctionService.GetAllAuctions(query);

            query.TotalAuctionsCount = result.TotalAuctions;
            query.TransmissionTypes = await _carService.GetAllTransmissionTypes();
            query.CarBodyTypes = await _carService.GetAllCarBodyTypes();
            query.Auctions = result.Auctions;

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AuctionFormModel
            {
                Makes = await _carService.GetAllMakes(),
                Drivetrains = await _carService.GetAllDrivetrains(),
                Transmissions = await _carService.GetAllTransmissions(),
                Fuels = await _carService.GetAllFuels(),
                CarBodies = await _carService.GetAllCarBodies()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuctionFormModel addModel)
        {
            if (await _validationService.MakeExists(addModel.MakeId) == false)
            {
                ModelState.AddModelError(nameof(addModel.MakeId), "Make does not exist");
            }

            if (await _validationService.DrivetrainExists(addModel.DrivetrainId) == false)
            {
                ModelState.AddModelError(nameof(addModel.DrivetrainId), "Drivetrain type does not exist");
            }

            if (await _validationService.FuelExists(addModel.FuelId) == false)
            {
                ModelState.AddModelError(nameof(addModel.FuelId), "Fuel type does not exist");
            }

            if (await _validationService.TransmissonExists(addModel.TransmissionId) == false)
            {
                ModelState.AddModelError(nameof(addModel.TransmissionId), "Transmission type does not exist");
            }

            if (await _validationService.CarBodyExists(addModel.CarBodyId) == false)
            {
                ModelState.AddModelError(nameof(addModel.CarBodyId), "Car body type does not exist");
            }

            if (!ModelState.IsValid)
            {
                addModel.Makes = await _carService.GetAllMakes();
                addModel.Drivetrains = await _carService.GetAllDrivetrains();
                addModel.Fuels = await _carService.GetAllFuels();
                addModel.Transmissions = await _carService.GetAllTransmissions();
                addModel.CarBodies = await _carService.GetAllCarBodies();

                return View(addModel);
            }

            await _auctionService.Create(addModel, User.Id());

            TempData[SuccessMessage] = "Auction created successfully.";
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await _auctionService.ExistsById(id) == false)
            {
                TempData[ErrorMessage] = "Auction doesnt exist.";
                return RedirectToAction(nameof(All));
            }

            if (await _auctionService.AuctionIsApproved(id) == false)
            {
                TempData[ErrorMessage] = "Auction doesnt exist.";
                return RedirectToAction(nameof(All));
            }

            var model = await _auctionService.GetAuctionDetailsById(id, User.Id());

            return View(model);
        }
    }
}