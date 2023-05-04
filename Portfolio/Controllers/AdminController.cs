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

        public IActionResult AdminServicesPage()
        {
            return View();
        }

        public IActionResult AdminShopSettings()
        {
            return View();
        }

        //// GET: AdminController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: AdminController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AdminController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AdminController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AdminController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AdminController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AdminController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
