namespace CarAuctionSystem.Services.Models.User
{
    public class UserServiceModel
    {
	    public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public int ActiveAuctionsCount { get; set; }

        public int PendingAuctionsCount { get; set; }
    }
}
