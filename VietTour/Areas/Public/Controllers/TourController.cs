using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VietTour.Areas.Public.Models;
using VietTour.Areas.Shared.Models;
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
            List<TourComponent> listTour = _mainRepository.TourRepository.GetAll(pageNumber, pageSize, sortBy, search);
            TourViewModel tourViewModel = new() {
                tourList = listTour
            };
            return View(tourViewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            TourDetailViewModel tourDetailViewModel = _mainRepository.TourRepository.GetTourDetail(id);
            return View(tourDetailViewModel);
        }
    }
}
