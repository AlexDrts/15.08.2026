using Microsoft.AspNetCore.Mvc;
using mvc.Services;

namespace mvc.Controllers
{
    public class MovieController : Controller
    {
        IMovieService movieService;
        IWebHostEnvironment env;

        public MovieController(IMovieService movieService, IWebHostEnvironment environment)
        {
            this.movieService = movieService;
            env = environment;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await movieService.GetAllAsync();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!ModelState.IsValid) return View(movie);

            if (movie.PosterFile != null)
                movie.PosterPath = await SavePoster(movie.PosterFile);

            await movieService.CreateAsync(movie);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.Id) return NotFound();

            if (!ModelState.IsValid) return View(movie);

            if (movie.PosterFile != null)
                movie.PosterPath = await SavePoster(movie.PosterFile);

            if (!await movieService.UpdateAsync(movie)) return NotFound();
            return RedirectToAction("Details", new { id = movie.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!await movieService.DeleteAsync(id)) return NotFound();
            return RedirectToAction("Index");
        }

        private async Task<string> SavePoster(IFormFile file)
        {
            var folder = Path.Combine(env.WebRootPath, "posters");
            Directory.CreateDirectory(folder);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName).ToLower();
            using (var stream = new FileStream(Path.Combine(folder, fileName), FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return "/posters/" + fileName;
        }
    }
}
