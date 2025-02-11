using Microsoft.AspNetCore.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    public class MovieController : Controller
    {
        private static List<Movie> movies = new List<Movie>()
        {
            new Movie{id= 1, Name="Movie 1"},
            new Movie{id= 2, Name="Movie 2"},
            new Movie{id= 3, Name="Movie 3"},
        };

        public IActionResult Index()
        {
            return View(movies);
        }

        public IActionResult Edit(int id)
        {
            var movie = movies.FirstOrDefault(m => m.id == id);
            if (movie == null)
                return NotFound();
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            var existingMovie = movies.FirstOrDefault(m => m.id == movie.id);
            if (existingMovie == null)
                return NotFound();

            existingMovie.Name = movie.Name;
            return RedirectToAction("Index");
        }
    }
}
