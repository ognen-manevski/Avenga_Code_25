using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

//CONVENTIONAL ROUTING
app.MapControllerRoute(
    name: "default", //not mandatory (leave it as "") , but recommended to name the route
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

//custom routing -> localhost:5001/courses/allcourses -> CoursesController -> AllCourses() action method
app.MapControllerRoute(
    "courses", //we can leave out the parameter
    pattern: "courses/allcourses",
    defaults: new { controller = "Courses", action = "GetAllCourses" }
    );

// localhost:5001/courses/C%23%20Basics
app.MapControllerRoute(
    name: "course_by_name_with_constraint",
    pattern: "courses/{name}",
    defaults: new { controller = "Courses", action = "GetCourseByName" },
    constraints: new { name = new MinLengthRouteConstraint(5) }
    );

app.MapControllerRoute(
    name: "courses_multiple_patterns",
    pattern: "courses/{id}/{name}",
    defaults: new { controller = "Courses", action = "GetCourseByNameAndId" },
    constraints: new {
        id = new IntRouteConstraint(),
        name = new MinLengthRouteConstraint(5)
        }
    );

app.MapControllerRoute(
    name: "courses_by_id",
    pattern: "courses/{id:int}", //same as adding a constraint in the constraints parameter
    defaults: new { controller = "Courses", action = "GetCourseById" }
    );

app.Run();
