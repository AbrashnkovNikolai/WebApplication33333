using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication33333.Models;

namespace WebApplication33333.Controllers
{
    public class FacultiesController : Controller
    {
        private readonly Dz2Context _context;

        public FacultiesController(Dz2Context context)
        {
            _context = context;
        }

        // GET: Faculties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Facultys.ToListAsync());
        }

        // GET: Faculties/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id== null)
            {
                return NotFound();
            }

            var faculty = await _context.Facultys
                .FirstOrDefaultAsync(m => m.GroupId== id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // GET: Faculties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Faculties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Faculty1,GroupName,YearOfAdmission,GroupId")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(faculty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(faculty);
        }

        // GET: Faculties/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id== null)
            {
                return NotFound();
            }

            var faculty = await _context.Facultys.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            return View(faculty);
        }

        // POST: Faculties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Faculty1,GroupName,YearOfAdmission,GroupId")] Faculty faculty)
        {
            if (id!= faculty.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(faculty.GroupId))
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
            return View(faculty);
        }

        // GET: Faculties/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id== null)
            {
                return NotFound();
            }

            // Получаем группу по ID
            var group = await _context.Facultys
                .Include(g => g.Students) // Подключаем студентов к группе
                .FirstOrDefaultAsync(g => g.GroupId== id); // Предполагается, что у группы есть свойство Id

            if (group == null)
            {
                return NotFound();
            }

            // Проверяем, есть ли студенты в группе
            if (group.Students != null && group.Students.Any())
            {
                TempData["ErrorMessage"] = "Невозможно удалить группу, так как в ней есть студенты.";
                return RedirectToAction(nameof(Index)); // Перенаправляем на индекс или другую страницу
            }

            return View(group);
        }

        // POST: Groups/Delete/5
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
                    return RedirectToAction(nameof(Index)); // Перенаправляем на индекс или другую страницу
                }

                _context.Facultys.Remove(group);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool FacultyExists(long id)
        {
            return _context.Facultys.Any(e => e.GroupId== id);
        }
    }
}
