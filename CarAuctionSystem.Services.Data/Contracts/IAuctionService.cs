﻿namespace CarAuctionSystem.Services.Data.Contracts
{
	using Models.Statistics;
	using Web.ViewModels.Auction;
	using Web.ViewModels.Bid;

	public interface IAuctionService
	{
		Task<AuctionQueryModel> GetAllAuctions(AllAuctionsQueryModel queryModel);

		Task<AuctionViewModel> GetAuctionViewModel(int id);

		Task<List<AuctionViewModel>> GetAllPendingAuctions();

		Task<List<AuctionViewModel>> GetAllPendingAuctionsByUserId(string userId);

		Task<PendingAuctionDetailsModel> GetPendingAuctionDetailsById(int id);

		Task Create(AuctionFormModel model, string userId);

		Task<bool> ExistsById(int id);

		Task<AuctionDetailsModel> GetAuctionDetailsById(int id, string userId);

		Task PlaceBid(BidFormModel model, string userId);

		Task<List<BidViewModel>> GetAllBids(int id);

		Task<StatisticsServiceModel> GetStatistics();

		Task ApproveAuction(int id);

		Task<bool> AuctionIsApproved(int id);

		Task<AuctionFormModel> GetPendingAuctionForEdit(int id);

		Task EditPendingAuctionByIdAndFormModel(int id, AuctionFormModel model);

		Task DeletePendingAuctionById(int id);
	}
}
