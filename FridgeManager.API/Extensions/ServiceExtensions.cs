using FridgeManager.Database;
using FridgeManager.Domain;
using FridgeManager.Interfaces;
using FridgeManager.LoggerService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FridgeManager.API.Extensions
{
    public static class ServiceExtensions
    {
        // CORS механизм для предоставления или ограничения права доступа к
        // приложениям из разных доменов
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        // настройка интеграции IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {
            });

        public static void ConfigureLoggerService(this IServiceCollection services) =>
             services.AddScoped<ILoggerManager, LoggerManager>();

        public static void ConfigureSqlContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<FridgeManagerDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                    b.MigrationsAssembly("FridgeManager.Domain")).EnableSensitiveDataLogging());

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<FridgeManagerDbContext>();
        }

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
