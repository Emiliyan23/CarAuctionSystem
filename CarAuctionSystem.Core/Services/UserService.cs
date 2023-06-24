namespace CarAuctionSystem.Core.Services
{
	using Microsoft.EntityFrameworkCore;

	using Contracts;
	using Infrastructure.Data;
	using Infrastructure.Data.Common;

	public class UserService : IUserService
	{
		private readonly IRepository _repo;

		public UserService(IRepository repo)
		{
			_repo = repo;
		}
		public async Task<bool> UserExists(string userId)
		{
			return await _repo.AllReadonly<ApplicationUser>()
				.AnyAsync(u => u.Id == Guid.Parse(userId));
		}
	}
}
