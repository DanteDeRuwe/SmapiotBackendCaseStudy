using System;
using System.Collections.Generic;
using System.Linq;

namespace SmapiotCaseStudy.Core.Models
{
    public class Report
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid SubscriptionId { get; set; }
        public int NumberOfRequests { get; set; }
        
        public int NumberOfServices => PriceReports.Count();
        public decimal TotalPrice => PriceReports.Aggregate(0m, (acc, val) => acc + val.TotalServicePrice);
        public IList<PriceReport> PriceReports { get; set; }
        
    }
}