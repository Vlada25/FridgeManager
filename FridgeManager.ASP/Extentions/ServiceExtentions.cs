namespace FridgeManager.ASP.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureHost(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddControllers();

            var host = configuration.GetValue<string>("Host");

            services.AddSingleton(host);
        }
    }
}
