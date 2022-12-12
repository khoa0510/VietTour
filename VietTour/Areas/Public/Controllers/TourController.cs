using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VietTour.Areas.Public.Models;
using VietTour.Data.Entities;
using VietTour.Data.Repositories;

namespace VietTour.Areas.Public.Controllers
{
    [Area("Public")]
    public class TourController : Controller
    {
        private readonly MainRepository _mainRepository;
        private readonly IMapper _mapper;

        public TourController(MainRepository mainRepository, IMapper mapper)
        {
            _mainRepository = mainRepository;
            _mapper = mapper;
        }

        [HttpGet] 
        public ActionResult Index(int? page, string sortBy, string search)
        {
            int pageSize = 12;
            int pageNumber = page ?? 1;
            List<Tour> tours = _mainRepository.TourRepository.GetAll(pageNumber, pageSize, sortBy, search);
            List<TourComponent> listTour = new();
            foreach (var tour in tours)
            {
                listTour.Add(_mapper.Map<TourComponent>(tour));
            }
            TourViewModel tourViewModel = new() {
                tourList = listTour
            };
            return View(tourViewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Tour tour = _mainRepository.TourRepository.GetTour(id);
            TourDetailViewModel tourDetailViewModel = _mapper.Map<TourDetailViewModel>(tour);
            return View(tourDetailViewModel);
        }
    }
}
