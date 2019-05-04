using AutoMapper;
using MovieManagement.DataModels;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Infrastructure.Mappings
{
    public class GenreToGenreViewModel : Profile
    {
        public GenreToGenreViewModel()
        {
            CreateMap<Genre, GenreViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedOn, opts => opts.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.ModifiedOn, opts => opts.MapFrom(src => src.ModifiedOn));
        }
    }
}
