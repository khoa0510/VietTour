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
                    return tours.OrderBy(t => t.Price).Skip(pageNumber).Take(pageSize).ToList();
                case "PRICE_DES":
                    return tours.OrderByDescending(t => t.Price).Skip(pageNumber).Take(pageSize).ToList();
            }
			return tours.OrderBy(t => t.TourName).Skip(pageNumber).Take(pageSize).ToList();
		}

        public Tour GetTour(int id)
        {
			var tours = _context.Tours.SingleOrDefault(t => t.TourId == id);
			return tours;
        }
    }
}
