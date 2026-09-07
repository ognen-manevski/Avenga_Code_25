using Microsoft.EntityFrameworkCore;
using NotesApp.DataAccess.Data;
using NotesApp.DataAccess.Interfaces;
using NotesApp.DataAccess.Implementations.EntityFramework;
using NotesApp.Services.Implementations;
using NotesApp.Services.Interfaces;
using NotesApp.DataAccess.Implementations.AdoNet;
using NotesApp.DataAccess.Implementations.Dapper;
using NotesApp.Helpers;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ===> Register the database
// AddDbContext makes the DbContext Scoped: a fresh one per HTTP request.
// Never a singleton - a DbContext remembers the objects it loaded, so sharing
// one would leak data between requests.
builder.Services.AddDbContext<NotesAppDbContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("NotesAppDb")));

// ===> Register services
builder.Services.AddRepositories(); // Register repositories

// ===> Register repositories
builder.Services.AddApplicationServices(); // Register application services

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
