using Microsoft.EntityFrameworkCore;
using System.Linq;
using VietTour.Data.Entities;

namespace VietTour.Data.Repositories
{
    public class TourRepository
	{
		private readonly ViettourContext _context;

		public TourRepository(ViettourContext viettourContext)
		{
			_context = viettourContext;
		}

		public List<Tour> GetAll(int pageNumber, int pageSize, string? sortBy, string? search)
		{
			var tours = _context.Tours.AsNoTracking();
			if(!string.IsNullOrEmpty(search))
			{
				tours = tours.Where(t => t.TourName.Contains(search) || t.Province.ProvinceName.Contains(search));
			}
			switch (sortBy)
			{
				case "PRICE":
					tours = tours.OrderBy(t => t.Price); break;
				case "PRICE_DES":
					tours = tours.OrderByDescending(t => t.Price); break;
			}
			return tours.Skip(pageNumber).Take(pageSize).ToList();
		}

        public Tour GetTour(int id)
        {
			var tours = _context.Tours.SingleOrDefault(t => t.TourId == id);
			return tours;
        }
    }
}
