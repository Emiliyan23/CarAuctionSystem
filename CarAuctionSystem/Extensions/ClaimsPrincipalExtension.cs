﻿namespace CarAuctionSystem.Extensions
{
	using System.Security.Claims;

	using static Core.Constants.GeneralConstants;

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
