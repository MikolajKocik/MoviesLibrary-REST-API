using Microsoft.EntityFrameworkCore;
using MoviesLibraryAPI.Entities;

namespace MoviesLibraryAPI.Data
{
    public class MoviesLibraryDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }


        public MoviesLibraryDbContext(DbContextOptions<MoviesLibraryDbContext> options) : base(options) { }

    }
}
