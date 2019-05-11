using MovieManagement.ViewModels;
using System.Collections.Generic;

namespace MovieManagement.Models.News
{
    public class ListNewsViewModel
    {
        public IEnumerable<NewsViewModel> News { get; set; }
    }
}