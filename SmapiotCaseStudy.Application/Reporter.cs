using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SmapiotCaseStudy.Core.Interfaces;
using SmapiotCaseStudy.Core.Models;

namespace SmapiotCaseStudy.Application
{
    public class Reporter :IReporter
    {
        private readonly IConfiguration _configuration;

        public Reporter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Report CreateReportFromRequests(IList<Request> requests, Guid subscription)
        {
            return new Report
            {
                StartDate = requests.Min(r => r.Requested),
                EndDate = requests.Max(r => r.Requested),
                SubscriptionId = subscription,
                NumberOfRequests = requests.Count(),
                PriceReport = requests.GroupBy(r => r.ServiceName).ToDictionary(
                    g => g.Key,
                    g => g.Count() * decimal.Parse(_configuration[$"servicePricing:{g.Key}"])
                )
            };
        }
    }
}