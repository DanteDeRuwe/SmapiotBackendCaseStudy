using System.Linq.Expressions;

namespace SmapiotCaseStudy.Core.Models
{
    public class PriceReport
    {
        public string ServiceName { get; set; }
        public int NumberOfRequests { get; set; }
        public decimal PricePerRequest { get; set; }
        public decimal TotalPrice => NumberOfRequests * PricePerRequest;
    }
}