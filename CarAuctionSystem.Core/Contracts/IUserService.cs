namespace CarAuctionSystem.Core.Contracts
{
	using Models.Auction;
	using Models.User;

	public interface IUserService
	{
		Task<bool> UserExists(string userId);

		Task<UserProfileModel> GetUserProfile(string userId);

		Task<string?> GetSellerIdByAuctionId(int auctionId);

		Task<bool> AuctionIsInWatchlist(int id, string userId);

		Task<IEnumerable<AllAuctionModel>> GetWatchlist(string userId);

		Task AddToWatchlist(int id, string userId);
	}
}
