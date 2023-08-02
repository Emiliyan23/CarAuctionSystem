namespace CarAuctionSystem.Web.ViewModels.Auction
{
	using System.ComponentModel.DataAnnotations;

	public class AllAuctionsQueryModel
	{
		[Display(Name = "Transmission")]
		public string? TransmissionType { get; set; }

		[Display(Name = "Body Style")]
		public string? CarBodyType { get; set; }

		[Display(Name = "Search auctions")]
		public string? SearchTerm { get; set; }

		[Display(Name = "From Year")]
		public int? StartYear { get; set; }

		[Display(Name = "To Year")]
		public int? EndYear { get; set; }

		[Display(Name = "View Type")]
		public string? ViewType { get; set; }

		public AuctionSorting Sorting { get; set; }

		public int TotalAuctionsCount { get; set; }

		public IEnumerable<string> TransmissionTypes { get; set; } = Enumerable.Empty<string>();

		public IEnumerable<string> CarBodyTypes { get; set; } = Enumerable.Empty<string>();

		public IEnumerable<AuctionViewModel> Auctions { get; set; } = Enumerable.Empty<AuctionViewModel>();
	}
}
