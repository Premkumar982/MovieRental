using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.Models;
using MovieRental.ViewModel;

namespace MovieRental.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var Movie = new Movie(){ MovieName="Frozen"};
            var Customers = new List<Customer>
            {
                new Customer { CustomerName="Premkumar"},
                new Customer { CustomerName="Jane"}
            };

            var viewModel = new RandomMovieViewModels
            {
                Movie = Movie,
                Customers = Customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("Id=" + id);
        }

        public ActionResult Index(int? PageIndex, string sortBy)
        {
            if (!PageIndex.HasValue)
            {
                PageIndex = 1;
            }
            if(string.IsNullOrEmpty(sortBy))
            {
                sortBy = "MovieName";
            }
            return Content(string.Format("pageIndex= {0}, Sortby = {1}", PageIndex, sortBy));
        }
        
        [Route("Movie/Released/{ReleaseYear}/{ReleaseMonth:regex(\\d{2}):range(1,12)}")]
        public ActionResult MoviesbyReleaseDate(int ReleaseYear, int ReleaseMonth)
        {

            return Content(string.Format("YEAR = {0}/{1} ", ReleaseMonth, ReleaseYear));
        }
    }
}