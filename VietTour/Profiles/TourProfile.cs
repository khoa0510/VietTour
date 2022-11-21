using AutoMapper;
using VietTour.Models.Entities;
using VietTour.Models.DTOs;

namespace VietTour.Profiles
{
	public class TourProfile : Profile
	{
		public TourProfile()
		{
			CreateMap<TourDTO, Tour>();
		}
	}
}
