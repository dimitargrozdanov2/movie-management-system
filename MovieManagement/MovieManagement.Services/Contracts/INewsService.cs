using MovieManagement.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.Services.Contracts
{
    public interface INewsService
    {
        News CreateNews(string title, IEnumerable<string> text);

        int DeleteNews(string title);

        News EditNewsText(string title, IEnumerable<string> text);
    }
}
