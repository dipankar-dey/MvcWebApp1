using MyFirstMVCWebApp.Models;
using MyFirstMVCWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCWebApp.Controllers
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
        public ActionResult Index()
        {
            List<Movie> movies = _context.Movies.ToList();

            foreach (Movie itemMovie in movies)
            {
                itemMovie.Genre = _context.Genres.Single(a => itemMovie.GenreId == a.Id);
            }

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            Movie selMovie = _context.Movies.Single(a => id == a.Id);
            selMovie.Genre = _context.Genres.Single(a => selMovie.GenreId == a.Id);
            return View(selMovie);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };

            var customers = new List<Customer>
            {
                new Customer{ Name="ABC" },
                new Customer{ Name="ABC1" }
            };


            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult New()
        {

            var genres = _context.Genres.ToList();
            

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
                

            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            try
            {

            
                if (!ModelState.IsValid)
                {
                    var viewModel = new MovieFormViewModel
                    {
                    
                        Genres=_context.Genres.ToList(),
                    
                        Name = movie.Name,
                        GenreId = movie.GenreId,
                        NumberInStock = movie.NumberInStock,
                        ReleaseDate = movie.ReleaseDate
                   
                    };
                    return View("MovieForm",viewModel);
                }

                if (movie.Id==0)
                {
                    movie.DateAdded = DateTime.Now;
                    int intIdt = _context.Movies.Max(u => u.Id);
                    movie.Id = intIdt + 1;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var movieInDb = _context.Movies.Single(m=>m.Id==movie.Id);

                
                    movieInDb.GenreId = movie.GenreId;
                
                    movieInDb.Name = movie.Name;
                    movieInDb.NumberInStock = movie.NumberInStock;
                    movieInDb.ReleaseDate = movie.ReleaseDate;

                
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.InnerException.Message);
            }

            var savedMovies = _context.Movies.ToList();
            return View("Index", savedMovies);
        }
    }
}