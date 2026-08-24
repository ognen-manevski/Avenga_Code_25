using Microsoft.EntityFrameworkCore;
using NotesApp.Domain.Models;

namespace NotesApp.DataAccess.Data;

public class NotesAppDbContext : DbContext
{

    public NotesAppDbContext(DbContextOptions<NotesAppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Note> Notes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Tag> Tags { get; set; }



    //using fluent api to configure the model
    //data annotations can also be used to configure the model but fluent api is more powerful and flexible
    //see User.cs
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Note>()
        //    .Property(note => note.Text)
        //    .IsRequired()
        //    .HasMaxLength(100);

        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("Note"); //changing the name to singular form if the dbset is pluralized

            entity.Property(note => note.Text)
                .IsRequired() //not null
                .HasMaxLength(100);

            entity.Property(note => note.Priority)
                .IsRequired()
                .HasConversion<string>() //store enum as string in db
                .HasMaxLength(30);

            //One to many relationship between User and Note
            entity.HasOne(note => note.User)
                .WithMany(user => user.Notes)
                .HasForeignKey(note => note.UserId)
                .OnDelete(DeleteBehavior.Cascade); //if user is deleted,
                                                   //delete all notes associated with that user

            //Many to many relationship between Note and Tag
            entity.HasMany(note => note.Tags)
                .WithMany() //no such property in Tag
                //create a join table
                .UsingEntity(
                    "NoteTag", //name of the join table
                    right => right.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagId"),
                    left => left.HasOne(typeof(Note)).WithMany().HasForeignKey("NoteId")
                );
        });

        base.OnModelCreating(modelBuilder);
    }





}

