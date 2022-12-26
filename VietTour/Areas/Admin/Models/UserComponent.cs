namespace VietTour.Areas.Admin.Models
{
    public class UserComponent
    {
        // giao diện người dùng - user
        public int UserId { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Username { get; set; }

        public string? Address { get; set; }
    }
}
