using Microsoft.Extensions.DependencyInjection;
using NotesApp.DataAccess.Implementations.EntityFramework;
using NotesApp.Services.Implementations;
using NotesApp.Services.Interfaces;
using NotesApp.DataAccess.Implementations.AdoNet;
using NotesApp.DataAccess.Implementations.Dapper;
using NotesApp.DataAccess.Interfaces;


namespace NotesApp.Helpers;

public static class DependencyInjectionHelper
{
    public static void AddRepositories(this IServiceCollection services)
    {
        // ===> Register repositories
        services.AddScoped<INoteRepository, NoteRepository>(); //EF Core implementation
        //services.AddScoped<INoteRepository, NoteRepositoryAdoNet>(); // Use ADO.NET implementation
        //services.AddScoped<INoteRepository, NoteRepositoryDapper>(); // Use Dapper implementation
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
    }

    public static void AddApplicationServices(this IServiceCollection services)
    {
        // ===> Register services
        services.AddScoped<INoteService, NoteService>();
        //services.AddScoped<IUserService, UserService>();
        //services.AddScoped<ITagService, TagService>();
    }


}
