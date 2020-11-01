using Microsoft.AspNetCore.Mvc;

namespace SmapiotCaseStudy.Api.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        public IActionResult Get()
        {
            return NoContent();
        }
    }
}