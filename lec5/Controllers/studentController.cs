using lec5.Data;
using lec5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lec5.Controllers
{
    [Authorize(Roles = "admin")]
    public class studentController : Controller
    {

        DataBase db;

        public studentController(DataBase _db)
        {
            db = _db;
        }

      
        public IActionResult Index()
        {
            
            return View(db.students.Include(a => a.Department).ToList()); //Eager Load (One request to join)
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.dept = new SelectList(db.Departments.ToList(), "Dept_Id", "Dept_Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(std);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dept = new SelectList(db.Departments.ToList(), "Dept_Id", "Dept_Name");
            return View(std);
        }

        [HttpGet]
        public IActionResult edit(int? id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult edit(Student student, int id)
        {
            Student NewStudent = db.students.FirstOrDefault(s => s.ID == id);
            NewStudent.Name = student.Name;
            NewStudent.Age = student.Age;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteStudent(int id)
        {
            Student student = db.students.FirstOrDefault(s => s.ID == id);
            db.students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            Student student = db.students.FirstOrDefault(s => s.ID == id);
         //   ViewBag.dep = db.students.Include(a => a.Department).ToList().FirstOrDefault(s => s.ID == id);
            if (id == null)
            {
                return BadRequest();
            }
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

      



    }
}



