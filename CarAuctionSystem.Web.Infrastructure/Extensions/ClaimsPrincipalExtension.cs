namespace CarAuctionSystem.Web.Infrastructure.Extensions
{
	using System.Security.Claims;

	using static Common.GeneralConstants;

	public static class ClaimsPrincipalExtension
	{
		public static string Id(this ClaimsPrincipal user)
		{
			return user.FindFirstValue(ClaimTypes.NameIdentifier);
		}

		public static bool IsAdmin(this ClaimsPrincipal user)
		{
			return user.IsInRole(AdminRoleName);
		}
	}
}
