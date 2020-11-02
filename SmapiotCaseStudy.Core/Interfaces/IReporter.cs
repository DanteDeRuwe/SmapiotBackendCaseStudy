using System;
using System.Collections.Generic;
using SmapiotCaseStudy.Core.Models;

namespace SmapiotCaseStudy.Core.Interfaces
{
    public interface IReporter
    {
        public Report CreateReportFromRequests(IList<Request> requests, Guid subscription);
    }
}