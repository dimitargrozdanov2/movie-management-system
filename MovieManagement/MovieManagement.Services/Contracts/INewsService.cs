using MovieManagement.DataModels;
using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Services.Contracts
{
    public interface INewsService
    {
        Task<NewsViewModel> CreateNewsAsync(DateTime Date, string title, string text, string imageUrl);

        Task<NewsViewModel> DeleteNews(string title);

        Task<NewsViewModel> EditNewsTextAsync(string title, NewsViewModel model);

        Task<ICollection<NewsViewModel>> GetAllNewsAsync();

        Task<NewsViewModel> GetNewsByNameAsync(string title);
    }
}
