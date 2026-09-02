using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Data;

public class DbContext
{
    /// <summary>
    /// Our database, as far as the C# code is concerned. 
    /// It does two things: 
    /// 1) every DbSet below becomes a table, and 
    /// 2) OnModelCreating() says what those tables look like.
    /// </summary>
    public class MoviesAppDbContext : DbContext
    {
        // EF Core passes in the options (provider + connection string).
        // Program.cs decides what they are; we never build them here.
        public MoviesAppDbContext(DbContextOptions<MoviesAppDbContext> options) : base(options)
        {
        }

        // The DbSet properties are the tables in our database. Each one is a collection of entities of that type.
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        // This method is called by EF Core when it is building the model.
        // We can use it to configure the model, e.g. to set up relationships, constraints, etc.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ===> Configure entities 
            modelBuilder.ConfigureActor();
            modelBuilder.ConfigureDirector();
            modelBuilder.ConfigureGenre();
            modelBuilder.ConfigureMovie();

            // ===> Seed data
            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }

    }
}
