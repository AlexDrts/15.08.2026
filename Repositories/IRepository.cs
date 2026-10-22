namespace mvc.Repositories
{
    public interface IRepository
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie?> GetByIdAsync(int id);
        Task AddAsync(Movie movie);
        Task UpdateAsync(Movie movie);
        Task DeleteAsync(Movie movie);
    }
}
