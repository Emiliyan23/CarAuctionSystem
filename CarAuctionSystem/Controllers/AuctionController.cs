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
		        return RedirectToAction(nameof(All));
	        }

	        var result = await _auctionService.GetAllAuctions(query);

	        query.TotalAuctionsCount = result.TotalAuctions;
	        query.Auctions = result.Auctions;
	        query.TransmissionTypes = await _carService.GetAllTransmissionTypes();
	        query.CarBodyTypes = await _carService.GetAllCarBodyTypes();

	        return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
	        if (User.HasValidPhoneNumber() == false)
	        {
		        TempData[InformationMessage] = "You must add valid phone number to sell a car.";
		        return RedirectToPage("/Account/Manage", new { area = "Identity" });
	        }

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
        public async Task<IActionResult> Add(AuctionFormModel formModel)
        {
            if (await _validationService.MakeExists(formModel.MakeId) == false)
            {
                ModelState.AddModelError(nameof(formModel.MakeId), "Make does not exist");
            }

            if (await _validationService.DrivetrainExists(formModel.DrivetrainId) == false)
            {
                ModelState.AddModelError(nameof(formModel.DrivetrainId), "Drivetrain type does not exist");
            }

            if (await _validationService.FuelExists(formModel.FuelId) == false)
            {
                ModelState.AddModelError(nameof(formModel.FuelId), "Fuel type does not exist");
            }

            if (await _validationService.TransmissonExists(formModel.TransmissionId) == false)
            {
                ModelState.AddModelError(nameof(formModel.TransmissionId), "Transmission type does not exist");
            }

            if (await _validationService.CarBodyExists(formModel.CarBodyId) == false)
            {
                ModelState.AddModelError(nameof(formModel.CarBodyId), "Car body type does not exist");
            }

            if (!ModelState.IsValid)
            {
                formModel.Makes = await _carService.GetAllMakes();
                formModel.Drivetrains = await _carService.GetAllDrivetrains();
                formModel.Fuels = await _carService.GetAllFuels();
                formModel.Transmissions = await _carService.GetAllTransmissions();
                formModel.CarBodies = await _carService.GetAllCarBodies();

                return View(formModel);
            }

            await _auctionService.Create(formModel, User.Id());

            TempData[SuccessMessage] = "Auction created successfully.";
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string extraInfo)
        {
            if (await _auctionService.ExistsById(id) == false)
            {
                TempData[ErrorMessage] = "Auction does not exist.";
                return RedirectToAction(nameof(All));
            }

            if (await _auctionService.AuctionIsApproved(id) == false)
            {
                TempData[ErrorMessage] = "Auction doesnt exist.";
                return RedirectToAction(nameof(All));
            }

            var model = await _auctionService.GetAuctionDetailsById(id, User.Id());

            if (extraInfo != model.GetExtraInfo())
            {
                TempData[ErrorMessage] = "Auction doesnt exist.";
                return RedirectToAction(nameof(All));
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
	        if (await _auctionService.ExistsById(id) == false)
	        {
		        TempData[ErrorMessage] = "Auction does not exist.";
		        return RedirectToAction(nameof(All));
	        }

	        if (User.IsAdmin() == false)
	        {
		        if (await _userService.GetSellerIdByAuctionId(id) != User.Id())
		        {
			        TempData[ErrorMessage] = "You must be seller in order to edit auction.";
			        return RedirectToAction(nameof(All));
		        }
	        }

	        if (await _auctionService.AuctionIsApproved(id))
	        {
		        TempData[ErrorMessage] = "Cannot edit approved auction.";
		        return RedirectToAction(nameof(All));
	        }

	        try
	        {
		        AuctionFormModel formModel = await _auctionService.GetPendingAuctionForEdit(id);
		        formModel.Makes = await _carService.GetAllMakes();
		        formModel.Drivetrains = await _carService.GetAllDrivetrains();
		        formModel.Fuels = await _carService.GetAllFuels();
		        formModel.CarBodies = await _carService.GetAllCarBodies();
		        formModel.Transmissions = await _carService.GetAllTransmissions();

		        return View(formModel);
	        }
	        catch (Exception)
	        {
		        return BadRequest();
	        }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AuctionFormModel formModel)
        {
	        if (await _validationService.MakeExists(formModel.MakeId) == false)
	        {
		        ModelState.AddModelError(nameof(formModel.MakeId), "Make does not exist");
	        }

	        if (await _validationService.DrivetrainExists(formModel.DrivetrainId) == false)
	        {
		        ModelState.AddModelError(nameof(formModel.DrivetrainId), "Drivetrain type does not exist");
	        }

	        if (await _validationService.FuelExists(formModel.FuelId) == false)
	        {
		        ModelState.AddModelError(nameof(formModel.FuelId), "Fuel type does not exist");
	        }

	        if (await _validationService.TransmissonExists(formModel.TransmissionId) == false)
	        {
		        ModelState.AddModelError(nameof(formModel.TransmissionId), "Transmission type does not exist");
	        }

	        if (await _validationService.CarBodyExists(formModel.CarBodyId) == false)
	        {
		        ModelState.AddModelError(nameof(formModel.CarBodyId), "Car body type does not exist");
	        }

	        if (!ModelState.IsValid)
	        {
		        formModel.Makes = await _carService.GetAllMakes();
		        formModel.Drivetrains = await _carService.GetAllDrivetrains();
		        formModel.Fuels = await _carService.GetAllFuels();
		        formModel.Transmissions = await _carService.GetAllTransmissions();
		        formModel.CarBodies = await _carService.GetAllCarBodies();

		        return View(formModel);
	        }

	        await _auctionService.EditPendingAuctionByIdAndFormModel(id, formModel);

	        return RedirectToAction("MyPendingAuctions", "User");
        }

        public async Task<IActionResult> Delete(int id)
        {
	        if (await _auctionService.ExistsById(id) == false)
	        {
		        TempData[ErrorMessage] = "Auction does not exist.";
		        return RedirectToAction("MyPendingAuctions", "User");
	        }

	        if (User.IsAdmin() == false)
	        {
		        if (await _userService.GetSellerIdByAuctionId(id) != User.Id())
		        {
			        TempData[ErrorMessage] = "You can only delete your own pending auctions.";
			        return RedirectToAction("MyPendingAuctions", "User");
		        }
	        }

	        await _auctionService.DeletePendingAuctionById(id);

	        return RedirectToAction("MyPendingAuctions", "User");
        }
    }
}