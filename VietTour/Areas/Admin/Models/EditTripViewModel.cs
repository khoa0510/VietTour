namespace VietTour.Areas.Admin.Models
{
    public class EditTripViewModel
    {
        // sửa trip - update

        public int TourId { get; set; }

        public DateTime DayStart { get; set; }

        public int Capacity { get; set; }
    }
}
