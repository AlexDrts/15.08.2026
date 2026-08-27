using Microsoft.AspNetCore.Mvc;

namespace mvc.Controllers
{
    public class MovieController : Controller
    {
        MovieContext db; 

        public MovieController(MovieContext context) 
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Movie> movies = await Task.Run(() => db.Movies.OrderBy(m => m.Id).ToList());
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            Movie? movie = await Task.Run(() => db.Movies.FirstOrDefault(m => m.Id == id));

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
    }
}
