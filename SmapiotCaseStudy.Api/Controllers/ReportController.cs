using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmapiotCaseStudy.Application;
using SmapiotCaseStudy.Core.Interfaces;

namespace SmapiotCaseStudy.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IRequestsService _requestsService;
        private readonly IReporter _reporter;

        public ReportController(IRequestsService requestsService, IReporter reporter)
        {
            _requestsService = requestsService;
            _reporter = reporter;
        }
        
        public async Task<IActionResult> Get(int year, int month, string subscription)
        {
            var requests = await _requestsService.GetBy(year, month, subscription);
            var report = _reporter.CreateReportFromRequests(requests, Guid.Parse(subscription));

            return Ok(report);
        }
    }
}