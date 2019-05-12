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
    public class NewsService : INewsService
    {
        private readonly MovieManagementContext context;
        private readonly IMappingProvider mappingProvider;

        public NewsService(MovieManagementContext context, IMappingProvider mappingProvider)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.mappingProvider = mappingProvider ?? throw new ArgumentNullException(nameof(mappingProvider));
        }

        public async Task<NewsViewModel> CreateNewsAsync(DateTime date, string title, string text, string imageUrl)
        {
            if (await this.context.News.AnyAsync(n => n.Title == title))
            {
                throw new EntityAlreadyExistsException($"News with title '{title}' already exists in the database.");
            }
            //var newstext = String.Join(" ", text);
            var news = new News { CreatedOn = DateTime.Now, Title = title, Text = text, ImageUrl = imageUrl };

            await this.context.News.AddAsync(news);

            await this.context.SaveChangesAsync();

            var returnNews = this.mappingProvider.MapTo<NewsViewModel>(news);

            return returnNews;
        }

        public async Task<ICollection<NewsViewModel>> GetAllNewsAsync()
        {
            var news = await this.context.News.OrderByDescending(x => x.CreatedOn).ToListAsync();

            var returnNews = this.mappingProvider.MapTo<ICollection<NewsViewModel>>(news);

            return returnNews;
        }

        public async Task<NewsViewModel> DeleteNews(string title)
        {
            bool titleExists = await this.context.News.AnyAsync(n => n.Title == title);
            if (titleExists == false)
            {
                throw new EntityInvalidException($"Title '{title}' does not exists, therefore we cannot remove the news");
            }
            var news = await this.context.News.FirstOrDefaultAsync(n => n.Title == title);

            this.context.News.Remove(news);

            await this.context.SaveChangesAsync();

            var returnNews = this.mappingProvider.MapTo<NewsViewModel>(news);

            return returnNews;
        }

        public async Task<NewsViewModel> EditNewsTextAsync(string title, NewsViewModel model)
        {
            bool titleExists = await this.context.News.AnyAsync(n => n.Title == title);
            if (titleExists == false)
            {
                throw new EntityInvalidException($"Title '{title}' does not exists, therefore we cannot change the text.");
            }
            var news = await this.context.News.FirstOrDefaultAsync(n => n.Title == title);
            var newstext = String.Join(" ", model.Text);

            news.ModifiedOn = DateTime.Now;
            news.Text = newstext;
            news.Title = model.Title;

            await this.context.SaveChangesAsync();

            var returnNews = this.mappingProvider.MapTo<NewsViewModel>(news);

            return returnNews;
        }

        public async Task<NewsViewModel> GetNewsByNameAsync(string title)
        {
            var news = await this.context.News
                .Include(x => x.Comments)
                    .ThenInclude(x => x.ApplicationUser)
                .FirstOrDefaultAsync(m => m.Title == title);

             if (news == null)
            {
                throw new EntityInvalidException($"News with title `{title}` does not exist.");
            }

            var comments = news.Comments.OrderByDescending(x => x.CreatedOn).ToList();
            //this is only done to sort the comments by time of creation
            news.Comments = comments;

           

            var returnNews = this.mappingProvider.MapTo<NewsViewModel>(news);

            return returnNews;
        }
    }
}