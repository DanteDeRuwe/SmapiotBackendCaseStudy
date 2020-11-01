using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmapiotCaseStudy.Application.Interfaces;

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
            var requests = await _service.GetBy(year, month);
            
            
            
            return NoContent(); //TODO temp
        }
    }
}