namespace VietTour.Areas.Admin.Models
{
    public class BookingComponent
    {
        //Id Tour
        public int TourId { get; set; }
        //Username đặt
        public string? Username { get; set; }
        //Tên Tour
        public string? TourName { get; set; }

        //Ngày bắt đầu
        public DateTime Create_Day { get; set; }

        public string? Note { get; set; }
    }
}
