using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRental.Models;

namespace MovieRental.ViewModel
{
    public class MovieViewModel
    {
        public Movie Movies { get; set; }
        public List<MovieGenre> MovieGenreList { get; set; }
    }
}