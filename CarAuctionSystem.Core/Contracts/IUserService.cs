namespace CarAuctionSystem.Services.Data.Contracts
{
    using Models.User;
    using Web.ViewModels.Auction;
	using Web.ViewModels.User;

	public interface IUserService
	{
		Task<bool> UserExists(string userId);

		Task<UserProfileModel> GetUserProfile(string userId);

		Task<string?> GetSellerIdByAuctionId(int auctionId);

		Task<bool> AuctionIsInWatchlist(int id, string userId);

		Task<IEnumerable<AuctionViewModel>> GetWatchlist(string userId);

		Task AddToWatchlist(int id, string userId);

		Task RemoveFromWatchlist(int id, string userId);

		Task<bool> IsHighestBidder(int id, string userId);

        Task<List<UserServiceModel>> All();
    }
}
