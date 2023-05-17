using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models.BookingsModels;

namespace Portfolio.Controllers
{
    public class AdminController : Controller
    {
        private readonly PortfolioContext _context;

        public AdminController(PortfolioContext context)
        {
            _context = context;
        }

        // GET: AdminController
        public IActionResult AdminPage()
        {
            var employees = from e in _context.Employees
                            orderby e.LastName
                            select e;

            return View(employees.ToList());
        }

        [HttpGet]
        public IActionResult AdminEmployeesPage()
        {
            var employees = from e in _context.Employees
                            orderby e.LastName
                            select e;

            return View(employees.ToList());
        }

        //[HttpGet]
        public IActionResult CreateNewEmployee()
        {
            Employee employee = new Employee();
            return PartialView("_AddEmployeePartialView", employee);
        }

        [HttpPost]
        public IActionResult CreateNewEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return RedirectToAction("AdminEmployeesPage", "Admin");
        }

        public IActionResult EditEmployee(int id)
        {
            Employee employee = _context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();

            return PartialView("_EditEmployeePartialView", employee);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("AdminEmployeesPage", "Admin");
        }

        public IActionResult DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();

            return PartialView("_DeleteEmployeePartialView", employee);
        }

        [HttpPost]
        public IActionResult DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("AdminEmployeesPage", "Admin");
        }

        public IActionResult AdminServicesPage()
        {
            return View();
        }

        public IActionResult AdminShopSettings()
        {
            return View();
        }

        
    }
}
