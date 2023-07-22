namespace CarAuctionSystem.Models
{
	using System.ComponentModel.DataAnnotations;
	using Core.Models.Auction;

	public class AllAuctionsQueryModel
	{
		[Display(Name = "Transmission")]
		public string? TransmissionType { get; set; }

		[Display(Name = "Body Style")]
		public string? CarBodyType { get; set; }

		[Display(Name = "Search auctions")]
		public string? SearchTerm { get; set; }

		public AuctionSorting Sorting { get; set; }

		public int CurrentPage { get; set; } = 1;

		public int TotalAuctionsCount { get; set; }

		public IEnumerable<string> TransmissionTypes { get; set; } = Enumerable.Empty<string>();

		public IEnumerable<string> CarBodyTypes { get; set; } = Enumerable.Empty<string>();

		public IEnumerable<AuctionViewModel> Auctions { get; set; } = Enumerable.Empty<AuctionViewModel>();
	}
}
