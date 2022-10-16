using Microsoft.EntityFrameworkCore;
using Rating_University.Data;

namespace Rating_University.Infrastructure.Extensions
{
    public static class ApplicationExtensions
    {
        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
                options.RoutePrefix = ConfigurationExtensions.getRouteSwagger();
            });
        }
        public static void ApplyMigrations(this IApplicationBuilder app)
        {

            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<Rating_UniversityDbContext>();

            dbContext.Database.Migrate();

        }
    }
}
