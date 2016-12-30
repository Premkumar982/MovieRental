using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string MovieName { get; set; }

        public MovieGenre MovieType { get; set; }

        public int MovieTypeId { get; set; }
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        public int NumberInStock { get; set; }
    }
}