namespace VietTour.Areas.Admin.Models
{
    public class CreateTripViewModel
    {
        // tạo lập trip

        public int TourId { get; set; }

        public DateTime DayStart { get; set; }

        public int Capacity { get; set; }
    }
}
