using AutoMapper;
using MovieManagement.DataModels;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieManagement.Infrastructure.Mappings
{
    public class MovieToMovieViewModel : Profile
    {
        public MovieToMovieViewModel()
        {
            //{
            //    this.ID = movie.ID;
            //    this.Name = movie.Name;
            //    this.Duration = movie.Duration;
            //    this.Storyline = movie.Storyline;
            //    this.Director = movie.Director;
            //    this.Genre = movie.Genre.Name;
            //    this.Rating = movie.Rating;
            //    this.VotesCount = movie.VotesCount;
            //    this.IsDeleted = movie.IsDeleted;
            //    this.Actors = movie.MovieActor
            //        .Select(x => x.Actor.Name)
            //        .ToList();
            CreateMap<Movie, MovieViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name))
                .ForMember(dest => dest.Duration, opts => opts.MapFrom(src => src.Duration))
                .ForMember(dest => dest.Storyline, opts => opts.MapFrom(src => src.Storyline))
                .ForMember(dest => dest.Director, opts => opts.MapFrom(src => src.Director))
                .ForMember(dest => dest.Genre, opts => opts.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Rating, opts => opts.MapFrom(src => src.Rating))
                .ForMember(dest => dest.VotesCount, opts => opts.MapFrom(src => src.VotesCount))
                .ForMember(dest => dest.IsDeleted, opts => opts.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.ImageUrl, opts => opts.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.Actors, opts => opts.MapFrom(src => src.MovieActor.Select(x => x.Actor.Name).ToList()));
        }
    }
}
