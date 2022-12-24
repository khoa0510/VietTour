using AutoMapper;
using VietTour.Areas.Admin.Models;
using VietTour.Areas.Public.Models;
using VietTour.Data.Entities;


namespace VietTour.Profiles
{
	public class TourProfile : Profile
	{
		public TourProfile()
		{
			CreateMap<CreateTourViewModel, Tour>();
			CreateMap<Tour, Areas.Admin.Models.TourComponent>();
            CreateMap<Tour, Areas.Public.Models.TourComponent>();
            CreateMap<Tour, TourDetailViewModel>();
        }
	}
}
