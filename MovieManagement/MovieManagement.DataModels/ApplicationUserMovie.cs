namespace MovieManagement.DataModels
{
    public class ApplicationUserMovie
    {
        public string MovieID { get; set; }
        public Movie Movie { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}