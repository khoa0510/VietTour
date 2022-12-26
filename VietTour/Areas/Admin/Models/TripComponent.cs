namespace VietTour.Areas.Admin.Models
{
    public class TripComponent
    {
        //trip id
        public int TripId { get; set; }

        public int TourId { get; set; }

        // ngày bắt đầu
        public DateTime DayStart { get; set; }

        // số lượng
        public int Capacity { get; set; }
    }
}
