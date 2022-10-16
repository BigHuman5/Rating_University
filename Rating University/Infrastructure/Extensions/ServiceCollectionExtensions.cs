using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Rating_University.Data;
using Rating_University.Data.Models;
using Rating_University.Features.Admin.Roles;
using Rating_University.Features.Identity;
using System.Text;

namespace Rating_University.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static AppSettings GetApplicationSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var applicationSettings = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettings);
            return applicationSettings.Get<AppSettings>();
        }

        public static IServiceCollection AddJwtAuthentication(
            this IServiceCollection services,
            AppSettings appSettings)
        {
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    ClockSkew = TimeSpan.Zero
                };
            });
            return services;
        }

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

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IIdentityServices,IdentitryServices>()
                .AddTransient<IRolesServices,RolesServices>();
        }
    }
}
