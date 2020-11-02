using Microsoft.Extensions.DependencyInjection;
using SmapiotCaseStudy.Core.Interfaces;

namespace SmapiotCaseStudy.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IReporter, Reporter>();
            services.AddTransient<IPriceReporter, PriceReporter>();
        }
    }
}