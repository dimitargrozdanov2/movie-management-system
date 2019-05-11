using AutoMapper;
using MovieManagement.DataModels;
using MovieManagement.ViewModels;

namespace MovieManagement.Infrastructure.Mappings
{
    public class NewsToNewsViewModel : Profile
    {
        public NewsToNewsViewModel()
        {
            this.CreateMap<News, NewsViewModel>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.CreatedOn, opts => opts.MapFrom(src => src.CreatedOn))
               .ForMember(dest => dest.ModifiedOn, opts => opts.MapFrom(src => src.ModifiedOn))
               .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
               .ForMember(dest => dest.Text, opts => opts.MapFrom(src => src.Text))
               .ForMember(dest => dest.Image, opts => opts.MapFrom(src => src.ImageUrl))
               .ForMember(dest => dest.Comments, opts => opts.MapFrom(src => src.Comments));
        }
    }
}