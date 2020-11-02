using System.Collections.Generic;
using SmapiotCaseStudy.Core.Models;

namespace SmapiotCaseStudy.Core.Interfaces
{
    public interface IPriceReporter
    {
        public IList<PriceReport> CreatePriceReportsFromRequests(IList<Request> requests);
    }
}