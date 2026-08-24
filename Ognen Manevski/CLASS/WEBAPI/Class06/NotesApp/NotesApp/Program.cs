using Microsoft.EntityFrameworkCore;
using NotesApp.DataAccess.Data;
using NotesApp.DataAccess.Implementations;
using NotesApp.DataAccess.Interfaces;
using NotesApp.Services.Implementations;
using NotesApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//register db
builder.Services.AddDbContext<NotesAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NotesAppDb")));

// Register services
builder.Services.AddScoped<INoteService, NoteService>();

// Register repositories
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
