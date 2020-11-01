using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmapiotCaseStudy.Application.Interfaces;
using SmapiotCaseStudy.Core.Models;

namespace SmapiotCaseStudy.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IRequestsService _service;

        public ReportController(IRequestsService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> Get(int year, int month, string subscription)
        {
            var requests = await _service.GetBy(year, month, subscription);
            var report = new Report
            {
                StartDate = requests.Min(r => r.Requested),
                EndDate = requests.Max(r => r.Requested),
                SubscriptionId = Guid.Parse(subscription),
                NumberOfRequests = requests.Count(),
                PriceReport =
                    requests.GroupBy(r => r.ServiceName)
                        .ToDictionary(g => g.Key, g => g.Count() * 1.00) //TODO price per service
            };

            return Ok(report);
        }
    }
}