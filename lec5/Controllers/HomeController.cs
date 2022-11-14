using lec5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using lec5.Data;

namespace lec5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult adddep()
        {
            DataBase db = new DataBase();
        
            Department dept1 = new Department() { Dept_Id=1 , Dept_Name=".NET"};
            db.Departments.Add(dept1);
            db.SaveChanges();
            return Content("added");
        }
    }
}