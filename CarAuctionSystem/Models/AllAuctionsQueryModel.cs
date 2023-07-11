namespace CarAuctionSystem.Models
{
	using System.ComponentModel.DataAnnotations;
	using Core.Models.Auction;

	public class AllAuctionsQueryModel
	{
		public const int AuctionsPerPage = 3;

		[Display(Name = "Search auctions")]
		public string? SearchTerm { get; set; }

		public AuctionSorting Sorting { get; set; }

		public int CurrentPage { get; set; } = 1;

		public int TotalAuctionsCount { get; set; }

		public IEnumerable<AllAuctionModel> Auctions { get; set; } = Enumerable.Empty<AllAuctionModel>();
	}
}
