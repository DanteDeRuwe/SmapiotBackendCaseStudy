using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmapiotCaseStudy.Application.Interfaces;
using SmapiotCaseStudy.Application.Mappers;

namespace SmapiotCaseStudy.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IRequestsService _service;
        private readonly IConfiguration _configuration;

        public ReportController(IRequestsService service, IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }
        
        public async Task<IActionResult> Get(int year, int month, string subscription)
        {
            var requests = await _service.GetBy(year, month, subscription);
            var report = new ReportMapper(_configuration).FromRequests(requests, Guid.Parse(subscription));

            return Ok(report);
        }
    }
}