using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication33333.Models;
namespace WebApplication33333.Controllers
{
    public class StudentsController : Controller
    {
        private readonly Dz2Context _context;

        public StudentsController(Dz2Context context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var dz2Context = _context.Students.Include(s => s.GroupNavigation);
            return View(await dz2Context.ToListAsync());
        }



        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["Group"] = new SelectList(_context.Facultys, "GroupId", "GroupId");
            ViewBag.degrees = new HashSet<string> { "бакалавр", "магистр", "аспирант" };
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentName,StudentSurname,StudentFatherName,Semester,Degree,Group")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Group"] = new SelectList(_context.Facultys, "GroupId", "GroupId", student.Group);
            ViewBag.degrees = new HashSet<string> { "бакалавр", "магистр", "аспирант" };
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.degrees = new HashSet<string> { "бакалавр", "магистр", "аспирант" };
            if (id== null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["Group"] = new SelectList(_context.Facultys, "GroupId", "GroupId", student.Group);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentName,StudentSurname,StudentFatherName,Semester,Degree,Group")] Student student)
        {
            if (id!= student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewBag.degrees = new HashSet<string> { "бакалавр", "магистр", "аспирант" };
            ViewData["Group"] = new SelectList(_context.Facultys, "GroupId", "GroupId", student.Group);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id== null)
            {
                return NotFound();
            }

            var group = await _context.Facultys
                .Include(g => g.Students) // Подключаем студентов к группе
                .FirstOrDefaultAsync(g => g.GroupId== id);

            if (group == null)
            {
                return NotFound();
            }

            // Проверяем, есть ли студенты в группе
            if (group.Students != null && group.Students.Any())
            {
                TempData["ErrorMessage"] = "Невозможно удалить группу, так как в ней есть студенты.";
                return RedirectToAction(nameof(Index)); // Перенаправляем на индекс
            }

            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var group = await _context.Facultys.FindAsync(id);
            if (group != null)
            {
                // Проверяем, есть ли студенты в группе перед удалением
                if (group.Students != null && group.Students.Any())
                {
                    TempData["ErrorMessage"] = "Невозможно удалить группу, так как в ней есть студенты.";
                    return RedirectToAction(nameof(Index)); // Перенаправляем на индекс
                }

                _context.Facultys.Remove(group);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id== id);
        }
    }
}
