using Blog.Application.Interfaces;
using Blog.Application.Service;
using Blog.Data.Context;
using Blog.Data.Repositories;
using Blog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.IoC
{
    public static class Infrastructure
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<BlogContext>(opt => opt.UseSqlite(configuration.GetConnectionString("Blog")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<INotificationService, WebSocketNotificationService>();


            return services;

        }

    }
}
