using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SmapiotCaseStudy.Core.Interfaces;
using SmapiotCaseStudy.Core.Models;

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
            if (!Guid.TryParse(subscription, out Guid subscriptionId))
                return BadRequest("please provide a valid subscription id format");

            IList<Request> requests = null;

            try
            {
                requests = await _requestsService.GetBy(year, month, subscriptionId);
            }
            catch (HttpRequestException hre)
            {
                return BadRequest("An error occured when trying to reach the request data collector: " + hre.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
            if (requests == null || !requests.Any())
                return NoContent();

            var report = _reporter.CreateReportFromRequests(requests, subscriptionId);

            return Ok(report);
        }
    }
}