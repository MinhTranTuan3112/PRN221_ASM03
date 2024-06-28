using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.DataAccess;

namespace SignalRAssignment.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddWebAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContextConfigurations(configuration)
                    .AddCorsConfigurations()
                    .AddSessionConfiguartions();
            return services;
        }

        private static IServiceCollection AddCorsConfigurations(this IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy("AllowAll", b => b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));
            return services;
        }

        private static IServiceCollection AddDbContextConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection")!;
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            return services;
        }

        private static IServiceCollection AddSessionConfiguartions(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            return services;
        }
    }
}