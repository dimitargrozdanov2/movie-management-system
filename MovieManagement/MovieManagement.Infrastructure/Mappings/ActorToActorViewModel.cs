using AutoMapper;
using MovieManagement.DataModels;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieManagement.Infrastructure.Mappings
{
    public class ActorToActorViewModel : Profile
    {
        public ActorToActorViewModel()
        {
            CreateMap<Actor, ActorViewModel>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.CreatedOn, opts => opts.MapFrom(src => src.CreatedOn))
               .ForMember(dest => dest.ModifiedOn, opts => opts.MapFrom(src => src.ModifiedOn))
               .ForMember(dest => dest.IsDeleted, opts => opts.MapFrom(src => src.IsDeleted))
               .ForMember(dest => dest.Movies, opts => opts.MapFrom(src => src.MovieActor.Select(x => x.Movie.Name).ToList()))
               .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
               .ForMember(dest => dest.MoviesImages, opts => opts.MapFrom(src => src.MovieActor.Select(x => x.Movie.ImageUrl).ToList()));


        }
    }
}
