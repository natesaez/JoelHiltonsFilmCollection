using Microsoft.EntityFrameworkCore;

namespace JoelHiltonsFilmCollection.Models;

public class MovieContext : DbContext
{
    public MovieContext(DbContextOptions<MovieContext> options) : base(options)
    {
    }
    
    public DbSet<NewMovie> NewMovies { get; set; }
}