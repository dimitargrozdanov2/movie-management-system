using MovieManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Models.News
{
    public class ListNewsViewModel
    {
        public IEnumerable<NewsViewModel> News { get; set; }
    }
}
