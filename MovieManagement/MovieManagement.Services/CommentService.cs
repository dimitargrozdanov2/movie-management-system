using Microsoft.EntityFrameworkCore;
using MovieManagement.Data;
using MovieManagement.DataModels;
using MovieManagement.Infrastructure;
using MovieManagement.Services.Contracts;
using MovieManagement.Services.Exceptions;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Services
{
    public class CommentService : ICommentService
    {
        private readonly MovieManagementContext context;
        private readonly IMappingProvider mappingProvider;

        public CommentService(MovieManagementContext context, IMappingProvider mappingProvider)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mappingProvider = mappingProvider ?? throw new ArgumentNullException(nameof(mappingProvider));
        }

        public async Task<CommentViewModel> AddComment(string commentText, string title, string userName)
        {
            var news = await this.context.News.Include(x => x.Comments).ThenInclude(x => x.ApplicationUser).FirstOrDefaultAsync(m => m.Title == title);

            var user = await this.context.Users.FirstOrDefaultAsync(m => m.UserName == userName);

            if (commentText == null)
            {
                throw new EntityInvalidException($"Text cannot be empty!");
            }

            var comment = new Comment { CreatedOn = DateTime.Now, Text = commentText, News = news, ApplicationUser = user };

            await this.context.Comments.AddAsync(comment);

            await this.context.SaveChangesAsync();

            var returnComment = this.mappingProvider.MapTo<CommentViewModel>(comment);

            return returnComment;
        }

        public async Task<ICollection<CommentViewModel>> GetAllComments()
        {
            var comments = await this.context.Comments
              .Include(c => c.ApplicationUser)
              .Include(x => x.News)
              .OrderByDescending(x => x.CreatedOn).ToListAsync();

            var returnComments = this.mappingProvider.MapTo<ICollection<CommentViewModel>>(comments);

            return returnComments;
        }
    }
}