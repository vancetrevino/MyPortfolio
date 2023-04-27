using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class BookingsController : Controller
    {
        [HttpGet("BookAppointment")]
        public IActionResult BookingsHomePage()
        {
            return View();
        }
    }
}
