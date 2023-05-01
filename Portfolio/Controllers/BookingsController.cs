using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.CodeAnalysis;
using Portfolio.Data;
using Portfolio.ViewModels.BookingsViewModels;

namespace Portfolio.Controllers
{
    public class BookingsController : Controller
    {
        private readonly PortfolioContext _context;

        public BookingsController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet("BookAppointment")]
        public IActionResult ChooseEmployee()
        {
            var employees = from e in _context.Employees
                            orderby e.LastName
                            select e;

            return View(employees.ToList());
        }

        [HttpPost]
        public IActionResult ChooseEmployee(EmployeeViewModel model)
        {


            return Ok();
        }
    }
}
