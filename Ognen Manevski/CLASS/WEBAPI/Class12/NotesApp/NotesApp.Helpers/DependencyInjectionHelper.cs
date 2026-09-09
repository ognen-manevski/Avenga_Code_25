using Microsoft.Extensions.DependencyInjection;
using NotesApp.DataAccess.Implementations.EntityFramework;
using NotesApp.Services.Implementations;
using NotesApp.Services.Interfaces;
using NotesApp.DataAccess.Implementations.AdoNet;
using NotesApp.DataAccess.Implementations.Dapper;
using NotesApp.DataAccess.Interfaces;
using Microsoft.Extensions.Configuration;
using NotesApp.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


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
        services.AddScoped<IAuthService, AuthService>();
    }

    public static void AddJwtAuthentiation(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // ===> Register the "JWT Settings" section

        //1 Bind the "JwtSettings" section 
        IConfigurationSection jwtSection = configuration.GetSection("JwtSettings");
        services.Configure<JwtSettings>(jwtSection); //bind the section to the JwtSettings Class and register it in the DI container

        //2 Read it here to use it for JWT authentication configuration
        JwtSettings jwtSettings = jwtSection.Get<JwtSettings>()!;

        //3 Configure JWT authentication
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                // A) Is this our token?
                ValidateIssuerSigningKey = true,
                //requires the token in byte array format
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

                // B) Did we issue this token?
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,

                //C) Is the token still valid?
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero // buffer time tolerance (none)
            };
        });
    }




}
