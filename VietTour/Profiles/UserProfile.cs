using AutoMapper;
using VietTour.Areas.Public.Models;
using VietTour.Data.Entities;

namespace VietTour.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<SignUpViewModel, User>();
            CreateMap<LogInViewModel, User>();
            CreateMap<EditUserViewModel, User>();
            CreateMap<User, EditUserViewModel>();
        }
    }
}
