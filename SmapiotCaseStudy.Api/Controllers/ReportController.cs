using Microsoft.AspNetCore.Mvc;

namespace SmapiotCaseStudy.Controllers
{
    public class ReportController : ControllerBase
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}