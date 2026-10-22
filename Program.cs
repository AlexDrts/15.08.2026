using Microsoft.EntityFrameworkCore;
using mvc.Repositories;
using mvc.Services;

namespace mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<MovieContext>(options => options.UseSqlServer(connection));

            builder.Services.AddScoped<IRepository, Repository>();
            builder.Services.AddScoped<IMovieService, MovieService>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.UseStatusCodePagesWithReExecute("/Error/{0}");

            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movie}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
