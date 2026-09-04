using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ===> Register the database
// AddDbContext makes the DbContext Scoped: a fresh one per HTTP request.
// Never a singleton - a DbContext remembers the objects it loaded, so sharing
// one would leak data between requests.
builder.Services.AddDbContext<DbContext>(options => options.UseSqlServer
    (builder.Configuration.GetConnectionString("MoviesAppDb")));






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
