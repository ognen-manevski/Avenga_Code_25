using System.Threading.RateLimiting;
using ToDoApp.DataAccess.Imlementations;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Domain;
using ToDoApp.Services.Implementations;
using ToDoApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//RegisterDatabase
string connectionString = builder.Configuration.GetConnectionString("ToDoAppConnectionString");
builder.Services.AddDbContext<ToDoAppDbContext>(options =>
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("ToDoApp.DataAccess")));


//DI for repositories

//builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
//builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
//builder.Services.AddScoped<IRepository<Status>, StatusRepository>();
builder.Services.AddScoped<IToDoRepository, EFToDoRepository>();
builder.Services.AddScoped<IRepository<Category>, EFCategoryRepository>();
builder.Services.AddScoped<IRepository<Status>, EFStatusRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IFilterService, FilterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
