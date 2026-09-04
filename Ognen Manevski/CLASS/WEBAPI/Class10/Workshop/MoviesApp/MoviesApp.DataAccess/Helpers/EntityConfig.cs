using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Helpers;

internal static class EntityConfig
{
    public static void ConfigureActor(this ModelBuilder modelBuilder)
    {

        // Better way to configure the Actor entity using the Fluent API
        // FLUENT API - everything about the Actor table, in one place.
        // User and Tag are configured on the classes themselves with Data Annotations (Attributes). Two styles, same result.
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.ToTable("Actor");

            // Id becomes the key by convention, because BaseEntity calls it "Id".
            // A differently named property would need entity.HasKey(...).

            entity.Property(actor => actor.FirstName)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(a => a.LastName)
                  .IsRequired()
                  .HasMaxLength(50);

            // ===> Many to Many relation (M:M)
            //configured in Movie entity
        });
    }


    public static void ConfigureDirector(this ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Director>(entity =>
        {
            entity.ToTable("Director");

            entity.Property(director => director.FirstName)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(director => director.LastName)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(director => director.DateOfBirth)
            //stored as date not datetime2
                .HasColumnType("date")
                .IsRequired(false);

            entity.HasMany(director => director.Movies)
                  .WithOne()
                  .HasForeignKey(movie => movie.DirectorId)
                  .IsRequired(false)
                  //dont delete cascade - that deletes the movies
                  .OnDelete(DeleteBehavior.SetNull);
        });
    }


    public static void ConfigureGenre(this ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(genre => genre.Name)
                  .IsRequired()
                  .HasMaxLength(50);
            //indexing for performance + uniqueness
            entity.HasIndex(genre => genre.Name)
                  .IsUnique();


            entity.HasMany(genre => genre.Movies)
                  .WithOne()
                  .HasForeignKey(movie => movie.GenreId)
                  .IsRequired()
                  //dont delete cascade -> that deletes the movies
                  //restrict doesnt allow deletion of genre
                  //if there are movies with that genre
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

    public static void ConfigureMovie(this ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.ToTable("Movie");

            entity.Property(movie => movie.Title)
                  .IsRequired()
                  .HasMaxLength(200);

            entity.Property(movie => movie.Description)
                  .IsRequired(false)
                  .HasMaxLength(1000);

            entity.Property(movie => movie.Year)
                  .IsRequired();
            //indexing for performance
            entity.HasIndex(movie => movie.Year);


            entity.Property(movie => movie.DurationMinutes)
                  .IsRequired();

            entity.Property(movie => movie.GenreId)
                  .IsRequired();
            //indexing for performance
            entity.HasIndex(movie => movie.GenreId);

            entity.Property(movie => movie.DirectorId)
                  .IsRequired(false);

            // ===> Many to Many relation (M:M)
            //only here not in Actor
            entity.HasMany(movie => movie.Actors)
                  .WithMany(actor => actor.Movies)
                  .UsingEntity(
                     "MovieActor",
                     right => right.HasOne(typeof(Movie)).WithMany().HasForeignKey("MovieId"),
                     left => left.HasOne(typeof(Actor)).WithMany().HasForeignKey("ActorId")
                  );
        });

    }


    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Drama" },
            new Genre { Id = 3, Name = "Comedy" },
            new Genre { Id = 4, Name = "Sci-Fi" },
            new Genre { Id = 5, Name = "Thriller" }
        );

        modelBuilder.Entity<Director>().HasData(
            new Director
            {
                Id = 1,
                FirstName = "Christopher",
                LastName = "Nolan",
                DateOfBirth = new DateTime(1970, 7, 30)
            },
            new Director
            {
                Id = 2,
                FirstName = "Steven",
                LastName = "Spielberg",
                DateOfBirth = new DateTime(1946, 12, 18)
            },
            new Director
            {
                Id = 3,
                FirstName = "Greta",
                LastName = "Gerwig",
                DateOfBirth = new DateTime(1983, 8, 4)
            },
            new Director
            {
                Id = 4,
                FirstName = "Unknown",
                LastName = "Director",
                DateOfBirth = null
            }
        );

        modelBuilder.Entity<Actor>().HasData(
            new Actor
            {
                Id = 1,
                FirstName = "Leonardo",
                LastName = "DiCaprio"
            },
            new Actor
            {
                Id = 2,
                FirstName = "Tom",
                LastName = "Hanks"
            },
            new Actor
            {
                Id = 3,
                FirstName = "Margot",
                LastName = "Robbie"
            },
            new Actor
            {
                Id = 4,
                FirstName = "Cillian",
                LastName = "Murphy"
            },
            new Actor
            {
                Id = 5,
                FirstName = "Emma",
                LastName = "Stone"
            }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                Id = 1,
                Title = "Inception",
                Description = "A thief who steals secrets through dreams.",
                Year = 2010,
                DurationMinutes = 148,
                GenreId = 4,
                DirectorId = 1
            },
            new Movie
            {
                Id = 2,
                Title = "The Dark Knight",
                Description = "Batman faces a dangerous criminal mastermind.",
                Year = 2008,
                DurationMinutes = 152,
                GenreId = 1,
                DirectorId = 1
            },
            new Movie
            {
                Id = 3,
                Title = "Catch Me If You Can",
                Description = "A young con artist is pursued by an FBI agent.",
                Year = 2002,
                DurationMinutes = 141,
                GenreId = 2,
                DirectorId = 2
            },
            new Movie
            {
                Id = 4,
                Title = "Barbie",
                Description = "Barbie leaves her perfect world and discovers reality.",
                Year = 2023,
                DurationMinutes = 114,
                GenreId = 3,
                DirectorId = 3
            },
            new Movie
            {
                Id = 5,
                Title = "Untitled Movie",
                Description = null,
                Year = 2025,
                DurationMinutes = 100,
                GenreId = 3,
                DirectorId = null
            }
        );

        // Many-to-many Actor <-> Movie
        modelBuilder.Entity("ActorMovie").HasData(
                new { MovieId = 1, ActorId = 1 },
                new { MovieId = 1, ActorId = 4 },
                new { MovieId = 2, ActorId = 4 },
                new { MovieId = 3, ActorId = 1 },
                new { MovieId = 3, ActorId = 2 },
                new { MovieId = 4, ActorId = 3 },
                new { MovieId = 4, ActorId = 5 },
                new { MovieId = 5, ActorId = 3 }
        );
    }

}


