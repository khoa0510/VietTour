using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VietTour.Areas.Admin.Models;
using VietTour.Areas.Shared.Models;
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

        public List<TourComponent> GetAll(int pageNumber, int pageSize, string? sortBy, string? search)
        {
            var tours = _context.Tours.AsNoTracking();
            if (!string.IsNullOrEmpty(search))
            {
                tours = tours.Where(t => !(!t.TourName.Contains(search) && !t.Province.ProvinceName.Contains(search)));
            }
            List<Tour> tourList;
            if (sortBy == "PRICE")
                tourList = tours.OrderBy(t => t.Price).Skip(pageNumber).Take(pageSize).ToList();
            else if (sortBy == "PRICE_DES")
                tourList = tours.OrderByDescending(t => t.Price).Skip(pageNumber).Take(pageSize).ToList();
            else
                tourList = tours.Skip(pageNumber).Take(pageSize).ToList();
            List<TourComponent> tourComponents = new List<TourComponent>();
            foreach (var tour in tourList)
            {
                var tourComponent = _mapper.Map<TourComponent>(tour);
                tourComponent.Image = ByteToImageFile(tour.Picture);
                tourComponents.Add(tourComponent);
            }
            return tourComponents;
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

            if (createTourViewModel.PictureFile.Length > 0)
                tour.Picture = FileImageToByte(createTourViewModel.PictureFile);

            _context.Add(tour);
            _context.SaveChanges();
            return true;
        }

        public Byte[] FileImageToByte(IFormFile file)
        {
            var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public string ByteToImageFile(Byte[] picture)
        {
            var base64 = Convert.ToBase64String(picture);
            return String.Format("data:image/jpg;base64,{0}", base64);
        }
    }
}
