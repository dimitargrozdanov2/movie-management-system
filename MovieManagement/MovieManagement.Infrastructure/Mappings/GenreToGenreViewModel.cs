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
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name));
        }
    }
}
