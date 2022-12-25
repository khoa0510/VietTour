using AutoMapper;
using VietTour.Areas.Admin.Models;
using VietTour.Areas.Public.Models;
using VietTour.Areas.Shared.Models;
using VietTour.Data.Entities;


namespace VietTour.Profiles
{
    public class TourProfile : Profile
	{
		public TourProfile()
		{
			CreateMap<CreateTourViewModel, Tour>();
			CreateMap<Tour, TourComponent>();
            CreateMap<Tour, TourDetailViewModel>();
        }
	}
}
