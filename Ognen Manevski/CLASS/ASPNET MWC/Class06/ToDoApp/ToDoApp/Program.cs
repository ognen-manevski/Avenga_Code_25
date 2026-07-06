using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DataAccess.Implementations;
using ToDoApp.Domain;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//=================================
//DEPENDENCY INJECTION
//=================================

// AddScoped means that a new instance of the service will be created for each HTTP request,
// and that same instance will be used throughout the request.
// This is useful for services that maintain state or need to be disposed of after the request is complete.

//always use interface as first argument and implementation class as second argument
builder.Services.AddScoped<IRepository<ToDo>, ToDoRepository>();
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Status>, StatusRepository>();

//AddTransient <==  creates a new instance every time it is requested
//AddScoped <==  creates only 1 instance per request (more efficient)
//=================================

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
