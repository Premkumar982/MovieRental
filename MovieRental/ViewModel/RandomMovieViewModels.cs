using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRental.Models;

namespace MovieRental.ViewModel
{
    public class RandomMovieViewModels
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}