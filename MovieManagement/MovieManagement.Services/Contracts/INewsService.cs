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
        Task<NewsViewModel> CreateNewsAsync(string title, string text, string imageUrl);

        Task<NewsViewModel> DeleteNews(string title);

        Task<NewsViewModel> EditNewsTextAsync(string title, IEnumerable<string> text, string imageUrl);


    }
}
