using lec5.Data;
using lec5.Migrations;
using Microsoft.AspNetCore.Mvc;

namespace lec5.Controllers
{
    public class DepatmentController : Controller
    {
        
            DataBase db;

            public DepatmentController(DataBase _db)
            {
                db = _db;
            }
            public IActionResult Index()
            {
                return View(db.Departments.ToList());
            }
        
    }
}
