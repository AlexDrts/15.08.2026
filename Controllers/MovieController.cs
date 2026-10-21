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

        // Список фільмів
        public async Task<IActionResult> Index()
        {
            var movies = await db.Movies.OrderBy(m => m.Id).ToListAsync();
            return View(movies);
        }

        // Детальна інформація
        public async Task<IActionResult> Details(int id)
        {
            var movie = await db.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // Створення
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie, IFormFile? posterFile)
        {
            CheckPosterFile(posterFile);
            if (!ModelState.IsValid) return View(movie);

            if (posterFile != null)
                movie.PosterPath = await SavePoster(posterFile);

            db.Movies.Add(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Редагування
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await db.Movies.FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie, IFormFile? posterFile)
        {
            if (id != movie.Id) return NotFound();
            if (!await db.Movies.AnyAsync(m => m.Id == id)) return NotFound();

            CheckPosterFile(posterFile);
            if (!ModelState.IsValid) return View(movie);

            if (posterFile != null)
                movie.PosterPath = await SavePoster(posterFile);

            db.Movies.Update(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Details", new { id = movie.Id });
        }

        // Видалення — сторінка підтвердження
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

        // Дозволяємо лише зображення
        private void CheckPosterFile(IFormFile? file)
        {
            if (file == null) return;

            var allowed = new[] { ".jpg", ".jpeg", ".png", ".webp", ".gif" };
            var ext = Path.GetExtension(file.FileName).ToLower();
            if (!allowed.Contains(ext))
                ModelState.AddModelError("posterFile", "Дозволені лише зображення: jpg, png, webp, gif");
        }

        // Зберігаємо файл у wwwroot/posters і повертаємо шлях до нього
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
