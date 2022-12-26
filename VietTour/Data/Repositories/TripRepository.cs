using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VietTour.Areas.Admin.Models;
using VietTour.Data.Entities;

namespace VietTour.Data.Repositories
{
    public class TripRepository
    {
        private readonly ViettourContext _context;
        private readonly IMapper _mapper;

        public TripRepository(ViettourContext viettourContext, IMapper mapper)
        {
            _context = viettourContext;
            _mapper = mapper;
        }

        public List<TripComponent> GetAll(int pageNumber, int pageSize, string? sortBy, string? search)
        {
            var trips = _context.Trips.AsNoTracking();
            if (!string.IsNullOrEmpty(search))
            {
                trips = trips.Where(t => int.Parse(DateTime.Now.Subtract(t.DayStart).ToString()) < 0);
            }
            List<Trip> tripList;
            if (sortBy == "DAY_DES")
                tripList = trips.OrderByDescending(t => t.DayStart).Skip(pageNumber).Take(pageSize).ToList();
            else tripList = trips.OrderBy(t => t.DayStart).Skip(pageNumber).Take(pageSize).ToList();
            
            List<TripComponent> tripComponents = new List<TripComponent>();
            foreach (var trip in tripList)
            {
                var tripComponent = _mapper.Map<TripComponent>(trip);
                tripComponents.Add(tripComponent);
            }
            return tripComponents;
        }

        public bool Create(CreateTripViewModel createTripViewModel)
        {
            var trip = _mapper.Map<Trip>(createTripViewModel);
            _context.Add(trip);
            _context.SaveChanges();
            return true;
        }

        public void Delete(int TripId)
        {
            var trip = _context.Trips.SingleOrDefault(t => t.TripId == TripId);
            _context.Trips.Remove(trip);
        }
    }
}
