using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mvc.Controllers
{
    public class MovieController : Controller
    {
        MovieContext db;
        IWebHostEnvironment env;

        public MovieController(MovieContext context, IWebHostEnvironment environment)
        {
            db = context;
            env = environment;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await db.Movies.OrderBy(m => m.Id).ToListAsync();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await db.Movies.FirstOrDefaultAsync(m => m.Id == id);
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

            db.Movies.Add(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await db.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.Id) return NotFound();
            if (!await db.Movies.AnyAsync(m => m.Id == id)) return NotFound();

            if (!ModelState.IsValid) return View(movie);

            if (movie.PosterFile != null)
                movie.PosterPath = await SavePoster(movie.PosterFile);

            db.Movies.Update(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", new { id = movie.Id });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movie = await db.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await db.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return NotFound();

            db.Movies.Remove(movie);
            await db.SaveChangesAsync();
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
