namespace CarAuctionSystem.Core.Contracts
{
	public interface IUserService
	{
		Task<bool> UserExists(string userId);
	}
}
