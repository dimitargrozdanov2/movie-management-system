using MovieManagement.DataModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieManagement.DataModels
{
    public class Comment : Entity
    {
        public string Text { get; set; }

        public string NewsID { get; set; }

        public News News { get; set; }

        public string Title { get; set; }

        public string ApplicationUserId { get; set; }

        public  ApplicationUser ApplicationUser {get; set;}
    }
}
