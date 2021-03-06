﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieRental.Models;
using MovieRental.ViewModel;

namespace MovieRental.Controllers
{
    public class MovieController : Controller
    {
        ApplicationDbContext _Context;

        public MovieController()
        {
            _Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        // GET: Movie
        public ActionResult Random()
        {
            var Movie = _Context.Movies.ToList();
            var Customers = new List<Customer>
            {
                new Customer { CustomerName="Premkumar"},
                new Customer { CustomerName="Jane Doe"}
            };

            var viewModel = new RandomMovieViewModels
            {
                Movie = Movie
                //Customers = Customers
            };
            return View(viewModel);
        }

        public ActionResult New()
        {
            var MovieGenre = _Context.MovieGenre.ToList();
            MovieViewModel Movieobj = new MovieViewModel()
            {
                MovieGenreList = MovieGenre
            };
            return View("MovieForm", Movieobj);
        }

        public ActionResult Edit(int Id)
        {
            var MovieDetails = _Context.Movies.SingleOrDefault(m => m.Id == Id);
            var MovieDetailsVM = new MovieViewModel()
            {
                Movies = MovieDetails,
                MovieGenreList = _Context.MovieGenre.ToList()
            };
            return View("MovieForm", MovieDetailsVM);
        }
        [ValidateAntiForgeryToken]
        public ActionResult SaveMovie(MovieViewModel MovieDetails)
        {
            if(ModelState.IsValid == false)
            {
                var MovieVM = new MovieViewModel()
                {
                    Movies = MovieDetails.Movies,
                    MovieGenreList = _Context.MovieGenre.ToList()
                };
                return View("MovieForm", MovieVM);
            }
            if (MovieDetails.Movies.Id == 0)
            {
                Movie objMovie = new Movie()
                {
                    MovieName = MovieDetails.Movies.MovieName,
                    MovieTypeId = MovieDetails.Movies.MovieTypeId,
                    NumberInStock = MovieDetails.Movies.NumberInStock,
                    ReleaseDate = MovieDetails.Movies.ReleaseDate,
                    DateAdded = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture))

            };
                _Context.Movies.Add(objMovie);
                
            }
            else
            {
                var dbMovieDetails = _Context.Movies.SingleOrDefault(m => m.Id == MovieDetails.Movies.Id);
                if(dbMovieDetails == null)
                {
                    return HttpNotFound();
                }


                dbMovieDetails.MovieName = MovieDetails.Movies.MovieName;
                dbMovieDetails.MovieTypeId = MovieDetails.Movies.MovieTypeId;
                dbMovieDetails.NumberInStock = MovieDetails.Movies.NumberInStock;
                dbMovieDetails.ReleaseDate = MovieDetails.Movies.ReleaseDate;
                dbMovieDetails.DateAdded = DateTime.Parse(DateTime.Now.ToString("dd/MM/yyyy"));

                
            }
            _Context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        //public ActionResult Index(int? PageIndex, string sortBy)
        public ActionResult Index()
        {
            /*if (!PageIndex.HasValue)
            {
                PageIndex = 1;
            }
            if(string.IsNullOrEmpty(sortBy))
            {
                sortBy = "MovieName";
            }
            return Content(string.Format("pageIndex= {0}, Sortby = {1}", PageIndex, sortBy));*/
            var Movie = _Context.Movies.Include(m=>m.MovieType).ToList();
            var MovieVM = new RandomMovieViewModels
            {
                Movie = Movie
            };
            return View(MovieVM);
        }
        [Route("Movie/Details/{MovieId}")]
        public ActionResult Details(int MovieId)
        {
            var Movie = _Context.Movies.Include(t => t.MovieType).Where(m => m.Id == MovieId);
            if(Movie == null)
            {
                return HttpNotFound();
            }
            var MovieVM = new RandomMovieViewModels
            {
                Movie = Movie.ToList()
            };
            return View(MovieVM);
        }

        [Route("Movie/Released/{ReleaseYear}/{ReleaseMonth:regex(\\d{2}):range(1,12)}")]
        public ActionResult MoviesbyReleaseDate(int ReleaseYear, int ReleaseMonth)
        {

            return Content(string.Format("YEAR = {0}/{1} ", ReleaseMonth, ReleaseYear));
        }
    }
}