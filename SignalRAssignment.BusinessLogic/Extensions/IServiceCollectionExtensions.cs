using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using SignalRAssignment.BusinessLogic.Interfaces;
using SignalRAssignment.BusinessLogic.Services;
using SignalRAssignment.DataAccess.Entities;
using SignalRAssignment.Shared.RequestModels;

namespace SignalRAssignment.BusinessLogic.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicDependencies(this IServiceCollection services)
        {
            services.AddMapsterConfigurations();
            services.AddScoped<IServiceFactory, ServiceFactory>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IPostCategoryService, PostCategoryService>();
            services.AddScoped<IAppUserService, AppUserService>();
            return services;
        }

        private static IServiceCollection AddMapsterConfigurations(this IServiceCollection services)
        {
            TypeAdapterConfig<UpdatePostRequest, Post>.NewConfig().IgnoreNullValues(true);
            return services;
        }
    }
}