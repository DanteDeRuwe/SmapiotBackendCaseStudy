using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmapiotCaseStudy.Core.Interfaces;
using SmapiotCaseStudy.Infrastructure.Services;

namespace SmapiotCaseStudy.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(
                "smapiotRequestDataCollector",
                client => client.BaseAddress = new Uri(configuration["RequestDataCollectorBaseUrl"])
            );

            services.AddTransient<IRequestsService, RequestsService>();
        }
    }
}