namespace VietTour.Areas.Admin.Models
{
    public class EditBookingViewModel
    {
        // sửa booking - update
        public int TourId { get; set; }

        //Tên Tour
        public string TourName { get; set; }

        public DateTime DayStart { get; set; }

        public int Passengers { get; set; }

        public DateTime CreateDate { get; set; }

        public string IsPaid { get; set; }

        public string? Note { get; set; }
    }
}
