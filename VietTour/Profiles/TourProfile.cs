using AutoMapper;
using VietTour.Areas.Public.Models;
using VietTour.Data.Entities;


namespace VietTour.Profiles
{
	public class TourProfile : Profile
	{
		public TourProfile()
		{
			CreateMap<Tour, TourComponent>();
            CreateMap<Tour, TourDetailViewModel>();
        }
	}
}
