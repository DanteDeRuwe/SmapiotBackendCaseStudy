using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SmapiotCaseStudy.Core.Interfaces;
using SmapiotCaseStudy.Core.Models;

namespace SmapiotCaseStudy.Application
{
    public class PriceReporter : IPriceReporter
    {
        private readonly IConfiguration _configuration;

        public PriceReporter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IList<PriceReport> CreatePriceReportsFromRequests(IList<Request> requests)
        {
            var grouped = requests.GroupBy(r => r.ServiceName);
            return grouped.Select(g => new PriceReport
            {
                ServiceName = g.Key,
                NumberOfRequests = g.Count(),
                PricePerRequest = decimal.Parse(_configuration[$"servicePricing:{g.Key}"])
            }).ToList();
        }
    }
}