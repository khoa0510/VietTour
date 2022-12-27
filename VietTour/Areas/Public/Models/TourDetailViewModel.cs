using VietTour.Areas.Shared.Models;

namespace VietTour.Areas.Public.Models
{
    public class TourDetailViewModel
    {
        public int TourId { get; set; }

        public string? TourName { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }

        // Danh sách các ngày của tour
        public List<DateTime> TripList { get; set; }

        // số khách
        public int Capacity { get; set; }


        //COMMENTS
        public List<CommentComponent> CommentList { get; set; }

        public List<TourComponent> tourList { get; set; }
    }
}
