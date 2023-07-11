namespace CarAuctionSystem.Core.Services
{
	using AutoMapper;
	using Microsoft.EntityFrameworkCore;

	using Common;
	using Contracts;
	using Infrastructure.Data.Common;
	using Infrastructure.Data.Models;
	using Models.Auction;
	using Models.Bid;
	using Models.Seller;

	public class AuctionService : IAuctionService
	{
		private readonly IRepository _repo;
		private readonly IMapper _mapper;

		public AuctionService(IRepository repo)
		{
			_repo = repo;
			_mapper = MapperConfig.InitializeMapper();
		}

		public async Task<AuctionQueryModel> GetAllAuctions(string? searchTerm = null,
			AuctionSorting sorting = AuctionSorting.Newest,
			int currentPage = 1,
			int auctionsPerPage = 1)
		{
			var result = new AuctionQueryModel();
			var auctions = _repo.AllReadonly<Auction>(); //iqueryable

			if (string.IsNullOrEmpty(searchTerm) == false)
			{
				searchTerm = $"%{searchTerm.ToLower()}%";
				auctions = auctions.Where(a => EF.Functions.Like(a.Make.Name.ToLower(), searchTerm) ||
				                               EF.Functions.Like(a.Model.ToLower(), searchTerm));
			}

			auctions = sorting switch
			{
				AuctionSorting.Oldest => auctions.OrderByDescending(a => a.StartDate),
				AuctionSorting.LowestMileage => auctions.OrderBy(a => a.Mileage),
				_ => auctions.OrderBy(a => a.StartDate)
			};

			result.Auctions = await auctions.Skip((currentPage - 1) * auctionsPerPage)
				.Take(auctionsPerPage)
				.Select(a => new AllAuctionModel
				{
					Id = a.Id,
					Make = a.Make.Name,
					Model = a.Model,
					EndDate = a.EndDate,
					ImageUrl = a.ImageUrl,
					Mileage = a.Mileage,
					ModelYear = a.ModelYear
				})
				.ToListAsync();

			result.TotalAuctions = await auctions.CountAsync();

			return result;
		}


		public async Task Create(AddAuctionModel model, string userId)
		{
			var auction = _mapper.Map<Auction>(model);
			auction.SellerId = Guid.Parse(userId);

			await _repo.AddAsync(auction);
			await _repo.SaveChangesAsync();
		}

		public async Task<bool> ExistsById(int id)
		{
			return await _repo.AllReadonly<Auction>()
				.AnyAsync(a => a.Id == id);
		}

		public async Task<AuctionDetailsModel> GetAuctionDetailsById(int id)
		{
			var auction = await _repo.AllReadonly<Auction>()
				.Where(a => a.Id == id)
				.Include(a => a.Seller)
				.Include(a => a.Drivetrain)
				.Include(a => a.Transmission)
				.Include(a => a.Fuel)
				.Include(a => a.CarBody)
				.FirstOrDefaultAsync();

			var model = _mapper.Map<AuctionDetailsModel>(auction);

			model.SellerDetails = new SellerDetailsModel
			{
				Id = auction!.SellerId.ToString(),
				Username = auction.Seller.UserName,
				Email = auction.Seller.Email,
				PhoneNumber = auction.Seller.PhoneNumber
			};

			model.Bids = await GetAllBids(id);

			return model;
		}

		public async Task PlaceBid(BidFormModel model, string userId)
		{
			var bid = new Bid
			{
				AuctionId = model.AuctionId,
				BidAmount = model.BidAmount,
				BidDate = DateTime.UtcNow,
				BidderId = Guid.Parse(userId)
			};

			await _repo.AddAsync(bid);
			await _repo.SaveChangesAsync();
		}

		public async Task<List<BidViewModel>> GetAllBids(int id)
		{
			List<Bid> bids = await _repo.AllReadonly<Bid>()
				.Where(b => b.AuctionId == id)
				.Include(b => b.Auction)
				.Include(b => b.Bidder)
				.ToListAsync();

			List<BidViewModel> bidModels = new List<BidViewModel>();
			foreach (var bid in bids)
			{
				var bidModel = new BidViewModel
				{
					BidderUsername = bid.Bidder.UserName,
					BidAmount = bid.BidAmount,
					BidDate = bid.BidDate
				};

				bidModels.Add(bidModel);
			}

			return bidModels;
		}
	}
}
