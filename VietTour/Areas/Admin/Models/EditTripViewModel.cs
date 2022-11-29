namespace VietTour.Areas.Admin.Models
{
    public class EditTripViewModel
    {
        // sửa trip - update
        public int TripId { get; set; }

        public int TourId { get; set; }

        public DateTime DayStart { get; set; }

        public int Capacity { get; set; }
    }
}
