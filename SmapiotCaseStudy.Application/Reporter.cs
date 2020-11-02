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
        private readonly IPriceReporter _priceReporter;

        public Reporter(IConfiguration configuration, IPriceReporter priceReporter)
        {
            _configuration = configuration;
            _priceReporter = priceReporter;
        }

        public Report CreateReportFromRequests(IList<Request> requests, Guid subscription)
        {
            return new Report
            {
                StartDate = requests.Min(r => r.Requested),
                EndDate = requests.Max(r => r.Requested),
                SubscriptionId = subscription,
                NumberOfRequests = requests.Count(),
                PriceReports = _priceReporter.CreatePriceReportsFromRequests(requests)
            };
        }
    }
}