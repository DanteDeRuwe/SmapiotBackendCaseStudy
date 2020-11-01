using System;
using System.Collections.Generic;

namespace SmapiotCaseStudy.Core.Models
{
    public class Report
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid SubscriptionId { get; set; }
        public int NumberOfRequests { get; set; }
        public IDictionary<string, double> PriceReport { get; set; }
    }
}