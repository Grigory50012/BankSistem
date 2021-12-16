using Contracts;
using Entities;
using LoggeService;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repository;

namespace BankSistem.Extensions
{
    static class ServiceExtensions
    {
        // For Configure CORS
        public static void ConfigureCors(this IServiceCollection service)
            => service.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()    //WithOrigins("https://example.com")
                    .AllowAnyMethod()   //WithMethods("POST", "GET")
                    .AllowAnyHeader());     //WithHeaders("accept", "content-type")
            });

        // For Deployent IIS
        public static void ConfigureIISIntegration(this IServiceCollection service)
            => service.Configure<IISOptions>(options =>
            {

            });

        // For Configure Logger Service
        public static void ConfigureLoggerService(this IServiceCollection service)
            => service.AddScoped<ILoggerManager, LoggerManager>();

        // For Connection SQLServer
        public static void ConfigureSqlContext(this IServiceCollection service, IConfiguration configuration)
            => service.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b =>
                    b.MigrationsAssembly("BankSistem"));
            });

        public static void ConfigureRepositoryManager(this IServiceCollection services)
            => services.AddScoped<IRepositoryManager, RepositoryManager>();
    }
}
