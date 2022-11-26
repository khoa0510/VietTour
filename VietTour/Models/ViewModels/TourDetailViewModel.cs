namespace VietTour.Models.ViewModels
{
    public class TourDetailViewModel
    {
        // tìm kiếm tour
        //public string find_Tour { get; set; }
        //tour id
        public int tour_id { get; set; }

        public int price { get; set; }

        // Danh sách các ngày của tour
        public List<TripComponent> tripList { get; set; }

        // số khách
        public int capacity { get; set; }


        //COMMENTS
        public List<CommentComponent> commentList { get; set; }





    }
}
