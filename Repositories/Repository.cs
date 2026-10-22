using Microsoft.EntityFrameworkCore;

namespace mvc.Repositories
{
    public class Repository : IRepository
    {
        MovieContext db;

        public Repository(MovieContext context)
        {
            db = context;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await db.Movies.OrderBy(m => m.Id).ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await db.Movies.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(Movie movie)
        {
            db.Movies.Add(movie);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            db.Movies.Update(movie);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Movie movie)
        {
            db.Movies.Remove(movie);
            await db.SaveChangesAsync();
        }
    }
}
