using Microsoft.AspNetCore.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    public class MovieController : Controller
    {
        List<Movie> movies = new List<Movie>();
        public IActionResult Index()
        {
            List<Movie> movies = new List<Movie>()
               {
                new Movie{id= 1,Name="movie 1"},
                new Movie{id=2,Name="movie 2"},
                new Movie{id=3,Name="movie 3"},
               };
            return View(movies);
        }
        public IActionResult Edit1(int id)
        {
            return Content("Test Id" + id);
        }
        public IActionResult ByRelease(int Year, int month)
        {
            return Content("MovieYear" +    Year +   month);
        }

        public  IActionResult Edit(int id)
        {
            
            var movie = movies.FirstOrDefault(m => m.id == id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            
            var existinMovie = movies.FirstOrDefault(m => m.id == movie.id);
            if (existinMovie == null)
                return NotFound();
            existinMovie.Name = movie.Name;
            return RedirectToAction("Index");
        }

    }
}
