using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            // Create List of customers
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer1"},
                new Customer { Name = "Customer2" }
            };

            // Create ViewModel
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            // Passing data to view
            // ViewData dictionary
            // ViewData["Movie"] = movie;
            // ViewBag
            // ViewBag.Movie = movie;
            // var viewResult = new ViewResult();
            // viewResult.ViewData.Model
            
            // Different ActionResult results
            return View(viewModel);
            //return Content("Hello world");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"}); // Action, Controller, context for next action
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();
            var viewModel = new MoviesFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel); // Specify View name
        }


        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MoviesFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
            
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                //TryUpdateModel(customerInDb);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.InStock = movie.InStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }



        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        public ViewResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            return View(movie);
        }



    }

 
}