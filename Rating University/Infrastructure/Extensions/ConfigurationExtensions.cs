namespace Rating_University.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static string getDefaultConnectionString(this IConfiguration config)
        {
            return config.GetConnectionString("DefaultConnection");
        }

        public static string getRouteSwagger() => "swagger";
    }
}
