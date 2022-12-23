using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using VietTour.Areas.Admin.Models;
using VietTour.Data.Entities;

namespace VietTour.Data.Repositories
{
    public class TourRepository
	{
		private readonly ViettourContext _context;
		private readonly IMapper _mapper;

		public TourRepository(ViettourContext viettourContext, IMapper mapper)
		{
			_context = viettourContext;
			_mapper = mapper;
		}

		public List<Tour> GetAll(int pageNumber, int pageSize, string? sortBy, string? search)
		{
			var tours = _context.Tours.AsNoTracking();
			if(!string.IsNullOrEmpty(search))
			{
				tours = tours.Where(t => !(!t.TourName.Contains(search) && !t.Province.ProvinceName.Contains(search)));
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

        public Tour? GetTour(int id)
        {
			var tours = _context.Tours.SingleOrDefault(t => t.TourId == id);
			return tours;
        }

		public List<string?> GetProvinceList()
		{
			var provinceList = _context.Provinces.Select(provinces => provinces.ProvinceName);
			return provinceList.ToList();
		}

		public bool CreateTour(CreateTourViewModel createTourViewModel)
		{
			Tour tour = _mapper.Map<Tour>(createTourViewModel);
			tour.ProvinceId = _context.Provinces.SingleOrDefault(p => p.ProvinceName == createTourViewModel.ProvinceName)?.ProvinceId;
            _context.Add(tour);
            _context.SaveChanges();
            return true;
        }
    }
}
