using Core.Repositories;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;
using static System.Net.Mime.MediaTypeNames;

namespace DataLayer
{
	public static class ServiceCollectionExtensions
	{
        public static IServiceCollection AddReposioryConnector(this IServiceCollection services)
        {


            services.AddScoped<IBaseUserRepository, BaseUserDB>();

            services.AddScoped<IPostRepository, PostDB>();
            //services.AddScoped<INotificationSettingRepository, NotificationSettingDb>();
            return services;
        }


    }
}
