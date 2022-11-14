using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lec5.Data;
using lec5.Models;

namespace lec5.Controllers
{
    public class courseController : Controller
    {
        private readonly DataBase _context;

        public courseController(DataBase context)
        {
            _context = context;
        }

        // GET: course
        public async Task<IActionResult> Index()
        {
              return View(await _context.coursess.ToListAsync());
        }

        // GET: course/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.coursess == null)
            {
                return NotFound();
            }

            var courses = await _context.coursess
                .FirstOrDefaultAsync(m => m.Cour_Id == id);
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // GET: course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cour_Id,Cour_name,Cour_Hours")] courses courses)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courses);
        }

        // GET: course/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.coursess == null)
            {
                return NotFound();
            }

            var courses = await _context.coursess.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }
            return View(courses);
        }

        // POST: course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cour_Id,Cour_name,Cour_Hours")] courses courses)
        {
            if (id != courses.Cour_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!coursesExists(courses.Cour_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(courses);
        }

        // GET: course/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.coursess == null)
            {
                return NotFound();
            }

            var courses = await _context.coursess
                .FirstOrDefaultAsync(m => m.Cour_Id == id);
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // POST: course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.coursess == null)
            {
                return Problem("Entity set 'DataBase.coursess'  is null.");
            }
            var courses = await _context.coursess.FindAsync(id);
            if (courses != null)
            {
                _context.coursess.Remove(courses);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool coursesExists(int id)
        {
          return _context.coursess.Any(e => e.Cour_Id == id);
        }
    }
}
