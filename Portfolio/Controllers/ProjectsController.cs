using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController (ILogger<ProjectsController> logger)
        {
            _logger = logger;
        }

        // GET: ProjectsController
        public ActionResult Projects()
        {
            return View();
        }
    }
}
