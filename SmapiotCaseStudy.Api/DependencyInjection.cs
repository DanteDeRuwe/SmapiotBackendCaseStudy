using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SmapiotCaseStudy.Api
{
    public static class DependencyInjection
    {
        public static void AddApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddOpenApiDocument(s =>
            {
                s.DocumentName = "apidocs";
                s.Title = "Smapiot Billing Engine API";
                s.Version = "v1";
                s.Description = "The API for the Smapiot Billing Engine. Built as a prototype by Dante De Ruwe.";
            });

            services.AddCors(options => options.AddPolicy("CORSPolicy", builder =>
                {
                    var methods = configuration.GetSection("CORS:Methods").Get<string[]>();
                    var origins = configuration.GetSection("CORS:Origins").Get<string[]>();
                    
                    builder.AllowAnyHeader().WithMethods(methods).WithOrigins(origins);
                })
            );
        }
    }
}