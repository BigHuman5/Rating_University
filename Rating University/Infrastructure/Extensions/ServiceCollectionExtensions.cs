using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Rating_University.Data;
using Rating_University.Data.Models;

namespace Rating_University.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services
            ,IConfiguration configuration)
        {
            return services.AddDbContext<Rating_UniversityDbContext>(options =>
            options.UseSqlServer(configuration.getDefaultConnectionString()));
        }

        public static IServiceCollection AddIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User, Role>()
                .AddEntityFrameworkStores<Rating_UniversityDbContext>();
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }
        public static void AddApiControllers(this IServiceCollection services)
        {
            //services
            //    .AddControllers();
        }

        /*public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //return services
            //    .AddTransient<>();
           // return null;
        }*/
    }
}
