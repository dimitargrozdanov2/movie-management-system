using AutoMapper;
using MovieManagement.DataModels;
using MovieManagement.ViewModels;

namespace MovieManagement.Infrastructure.Mappings
{
    public class UserToUserViewModel : Profile
    {
        public UserToUserViewModel()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opts => opts.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opts => opts.MapFrom(src => src.Email));


        }
    }
}
