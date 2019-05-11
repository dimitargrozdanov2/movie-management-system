using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services.Contracts
{
    public interface ICommentService
    {
        Task<CommentViewModel> AddComment(string commentText, string title, string userName);

        Task<ICollection<CommentViewModel>> GetAllComments();

    }
}
