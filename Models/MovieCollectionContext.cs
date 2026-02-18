using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class MovieCollectionContext : DbContext
    {
        public MovieCollectionContext(DbContextOptions<MovieCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Category = "Action",
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christopher Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = null,
                    Notes = "All-time fav"
                },
                new Movie
                {
                    MovieId = 2,
                    Category = "Adventure",
                    Title = "The Lord of the Rings",
                    Year = 2001,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = null,
                    LentTo = null,
                    Notes = "Epic"
                },
                new Movie
                {
                    MovieId = 3,
                    Category = "Animation",
                    Title = "Toy Story",
                    Year = 1995,
                    Director = "John Lasseter",
                    Rating = "G",
                    Edited = null,
                    LentTo = "My brother",
                    Notes = "Classic"
                }
            );
        }
    }
}
