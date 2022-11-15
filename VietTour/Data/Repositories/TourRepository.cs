using AutoMapper;
using VietTour.Entities;

namespace VietTour.Data.Repositories
{
	public class TourRepository
	{
		private readonly ViettourContext _context;

		public TourRepository(ViettourContext viettourContext)
		{
			_context = viettourContext;
		}

		public List<Tour> GetAll()
		{
			return _context.Tours.ToList();
		}
	}
}
