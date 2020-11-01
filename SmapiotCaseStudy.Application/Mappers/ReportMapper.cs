using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SmapiotCaseStudy.Core.Models;

namespace SmapiotCaseStudy.Application.Mappers
{
    public class ReportMapper
    {
        private readonly IConfiguration _configuration;

        public ReportMapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Report FromRequests(IList<Request> requests, Guid subscription)
        {
            return new Report
            {
                StartDate = requests.Min(r => r.Requested),
                EndDate = requests.Max(r => r.Requested),
                SubscriptionId = subscription,
                NumberOfRequests = requests.Count(),
                PriceReport =
                    requests.GroupBy(r => r.ServiceName)
                        .ToDictionary(g => g.Key, g => g.Count() * decimal.Parse(_configuration[$"servicePricing:{g.Key}"]))
            };
        }
    }
}