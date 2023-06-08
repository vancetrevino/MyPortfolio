using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data;
using Portfolio.Models.BookingsModels;
using Portfolio.ViewModels.BookingsViewModels;
using System.Net;

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
            //var employees = from e in _context.Employees
            //                orderby e.LastName
            //                select e;

            //return View(employees.ToList());
            return View();
        }

        [HttpGet]
        public IActionResult AdminEmployeesPage()
        {
            var employees = from e in _context.Employees
                            orderby e.LastName
                            select e;

            var employeeViewModelList = new List<EmployeeViewModel>();

            foreach (var em in employees)
            {
                var employeeVM = new EmployeeViewModel
                {
                    Employee = em
                };
                employeeVM.AllServices = _context.Services.ToList();
                employeeViewModelList.Add(employeeVM);
            }

            return View(employeeViewModelList);
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

        public IActionResult EditEmployee(int? id)
        {
            Employee employee = _context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();

            return PartialView("_EditEmployeePartialView", employee);
        }

        [HttpPost]
        public IActionResult EditEmployee(Employee employee)
        //public IActionResult EditEmployee(EmployeeViewModel employeeVM)
        {
            //Employee employee = employeeVM.Employee;
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("AdminEmployeesPage", "Admin");
        }

        public IActionResult DeleteEmployee(int? id)
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
            var services = from e in _context.Services
                           orderby e.ServiceGroup
                           select e;

            return View(services.ToList());
        }

        public IActionResult EditEmployeeServices(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCode();
            }

            var employeeViewModel = new EmployeeViewModel
            {
                Employee = _context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault()
            };

            if (employeeViewModel == null)
            {
                //return HttpNotFound();
            }

            employeeViewModel.AllServices = _context.Services.ToList();

            return PartialView("_EmployeeServicesPartialView", employeeViewModel);
        }

        public IActionResult AdminShopSettings()
        {
            return View();
        }

        
    }
}
