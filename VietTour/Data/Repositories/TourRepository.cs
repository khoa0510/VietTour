using AutoMapper;
using Microsoft.IdentityModel.Tokens;
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

		public IEnumerable<Tour> GetAll(int pageNumber, int pageSize, string sortBy, string search)
		{
			var tours = from t in _context.Tours select t;
			if(!String.IsNullOrEmpty(search))
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
			return tours;
		}
	}
}
