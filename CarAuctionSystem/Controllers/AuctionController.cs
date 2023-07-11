﻿namespace CarAuctionSystem.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using Core.Contracts;
	using Core.Models.Auction;
	using Extensions;
	using Models;

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
		public async Task<IActionResult> All([FromQuery]AllAuctionsQueryModel query)
		{
			var result = await _auctionService.GetAllAuctions(query.TransmissionType,
				query.CarBodyType,
				query.SearchTerm,
				query.Sorting,
				query.CurrentPage,
				AllAuctionsQueryModel.AuctionsPerPage);

			query.TotalAuctionsCount = result.TotalAuctions;
			query.TransmissionTypes = await _carService.GetAllTransmissionTypes();
			query.CarBodyTypes = await _carService.GetAllCarBodyTypes();
			query.Auctions = result.Auctions;

			return View(query);
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new AddAuctionModel
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
		public async Task<IActionResult> Add(AddAuctionModel addModel)
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

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> Details(int auctionId)
		{
			if (await _auctionService.ExistsById(auctionId) == false)
			{
				return BadRequest();
			}

			var model = await _auctionService.GetAuctionDetailsById(auctionId);

			return View(model);
		}
	}
}