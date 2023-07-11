namespace CarAuctionSystem.Core.Contracts
{
	using Models.User;

	public interface IUserService
	{
		Task<bool> UserExists(string userId);

		Task<UserProfileModel> GetUserProfile(string userId);
	}
}
