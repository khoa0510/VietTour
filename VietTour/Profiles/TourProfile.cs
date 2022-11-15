using AutoMapper;
using VietTour.Entities;
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
