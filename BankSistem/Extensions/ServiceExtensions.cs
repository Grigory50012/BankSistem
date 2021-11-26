using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
