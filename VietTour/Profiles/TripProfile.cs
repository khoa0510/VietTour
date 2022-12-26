using AutoMapper;
using VietTour.Areas.Admin.Models;
using VietTour.Data.Entities;

namespace VietTour.Profiles
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            CreateMap<Trip, TripComponent>();
            CreateMap<CreateTripViewModel, Trip>();
        }
    }
}
