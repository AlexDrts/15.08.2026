using mvc.Repositories;

namespace mvc.Services
{
    public class MovieService : IMovieService
    {
        IRepository repository;

        public MovieService(IRepository repository)
        {
            this.repository = repository;
        }

        public Task<List<Movie>> GetAllAsync()
        {
            return repository.GetAllAsync();
        }

        public Task<Movie?> GetByIdAsync(int id)
        {
            return repository.GetByIdAsync(id);
        }

        public Task CreateAsync(Movie movie)
        {
            return repository.AddAsync(movie);
        }

        public async Task<bool> UpdateAsync(Movie movie)
        {
            if (await repository.GetByIdAsync(movie.Id) == null) return false;

            await repository.UpdateAsync(movie);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var movie = await repository.GetByIdAsync(id);
            if (movie == null) return false;

            await repository.DeleteAsync(movie);
            return true;
        }
    }
}
