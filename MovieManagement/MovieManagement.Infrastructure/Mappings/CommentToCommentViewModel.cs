using AutoMapper;
using MovieManagement.DataModels;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Infrastructure.Mappings
{
    public class CommentToCommentViewModel : Profile
    {
        public CommentToCommentViewModel()
        {
            CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.CreatedOn, opts => opts.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.Text, opts => opts.MapFrom(src => src.Text));
        }
    }
}
