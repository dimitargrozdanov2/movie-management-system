using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManagement.ViewModels
{
    public class ActorViewModel
    {
        public string Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public ICollection<string> Movies { get; set; }

        public ICollection<string> MoviesImages { get; set; }
    }
}
