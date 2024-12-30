using System;

namespace EntityFrameworkCodeFirstMovie.DAL.Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } // allows it to be customized by overriding it in derived classes.
    }
}
