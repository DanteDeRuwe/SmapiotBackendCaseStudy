using System;

namespace SmapiotCaseStudy.Core.Models
{
    public class Request
    {
        public Guid Id { get; set; }
        public DateTime Requested { get; set; }
        public TimeSpan Duration { get; set; }
        public string ServiceName { get; set; }
        public Guid SubscriptionId { get; set; }
        public string OriginIp { get; set; }
        public string Target { get; set; }
    }
}