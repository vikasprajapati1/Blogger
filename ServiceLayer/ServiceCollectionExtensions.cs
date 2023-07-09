using Core.Repositories;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
	public static class ServiceCollectionExtensions
	{
        public static IServiceCollection AddServiceConnector(this IServiceCollection services)
        {
            //if (cacheProvider == "Redis")
            //{
            //    var connectionString = configuration["Cache:Redis:ConnectionString"];
            //    Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            //    {
            //        return ConnectionMultiplexer.Connect(connectionString);
            //    });
            //    services.AddSingleton<IConnectionMultiplexer>(lazyConnection.Value);
            //    services.AddScoped<ICacheService, RedisCache>();
            //    services.AddSingleton<IGlobalCacheService, GlobalRedisCache>();
            //}
            //else if (cacheProvider == "InMemory")
            //{
            //    services.AddScoped<ICacheService, InMemoryCache>();
            //    services.AddSingleton<IGlobalCacheService, GlobalInMemoryCache>();
            //}

            //if (messageServiceProvider == "Rabbit")
            //{
            //    services.AddScoped<IMessageService, Rabbit>();

            //}

          
            services.AddScoped<IBaseUserService, BaseUserService>();
            services.AddScoped<IPostService, PostService>();
           
            return services;
        }
    }
}
