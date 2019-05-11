using Microsoft.AspNetCore.Mvc;
using MovieManagement.Models.Comment;
using MovieManagement.Services.Contracts;
using MovieManagement.ViewModels;
using System;
using System.Threading.Tasks;

namespace MovieManagement.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
        }

        [HttpGet]
        public IActionResult Comment()
        {
            var model = new CommentViewModel();
            return this.View(model);
        }

        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(CreateCommentViewModel model)
        {
            var role = await this.commentService.AddComment(model.Text, model.Title, model.User);

            return this.RedirectToAction("Details", "News", new { Id = model.Title });
        }
    }
}