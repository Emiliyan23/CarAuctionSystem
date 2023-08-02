namespace CarAuctionSystem.Web.Infrastructure.Extensions
{
	using ViewModels;

	public static class ModelExtensions
	{
		public static string GetExtraInfo(this IAuctionModel auction)
		{
			string extraInfo = $"{auction.ModelYear}-{auction.Make}-{auction.Model}";

			return extraInfo.Trim()
				.Replace(' ', '-');
		}
	}
}
