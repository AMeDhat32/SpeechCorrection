using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

namespace SpeechCorrection.APIs.Extensions
{
    public static class SwaggerServicesExtension
    {
        public static IServiceCollection AddSwaggerServices(this IServiceCollection Services)
        {
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpeechCorrection", Version = "v1" });
            });

            return Services;
        }

        public static WebApplication AddSwaggerMiddleware(this WebApplication app)
        {
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "openapi/{documentName}.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/openapi/v1.json", "SpeechCorrection API");
                
            });

            return app;
        }
    }
}
