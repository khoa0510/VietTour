namespace VietTour.Areas.Admin.Models
{
    public class EditUserViewModel
    {
        public int UserId { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string? Username { get; set; }

        public string? Address { get; set; }

        public bool Admin { get; set; }

        public string? Password { get; set; }
    }
}
