namespace VietTour.Areas.Admin.Models
{
    public class BookingComponent
    {
        public int BookingId { get; set; }
        //Id Tour

        public string? Username { get; set; }

        //Tên Tour
        public string? TourName { get; set; }

        public int? Passengers { get; set; }

        public bool IsPaid { get; set; }
    }
}
