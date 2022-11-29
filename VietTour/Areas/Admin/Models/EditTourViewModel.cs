namespace VietTour.Areas.Admin.Models
{
    public class EditTourViewModel
    {
        // sửa tour - update
        public int TourId { get; set; }

        public string? TourName { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int ProvinceId { get; set; }
    }
}
