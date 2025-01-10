using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication33333.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication33333.Controllers
{
    public class GiftedGrantsController : Controller
    {
        private readonly Dz2Context _context;

        public GiftedGrantsController(Dz2Context context)
        {
            _context = context;
        }

        // GET: GiftedGrants
        public async Task<IActionResult> Index()
        {
            var dz2Context = _context.GiftedGrants
                .Include(g => g.GrantNameNavigation)
                .Include(g => g.Student);
            return View(await dz2Context.ToListAsync());
        }


        // GET: GiftedGrants/Create
        [HttpGet ]
        public IActionResult Create()
        {
            Console.WriteLine("saaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            ViewData["GrantName"] = new SelectList(_context.GrantsInfos, "GrantName", "GrantName");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");

           
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(int? StudentId, string? GrantName, int? GrantValue)
        {
            Console.WriteLine("saaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            _context.Add(new GiftedGrant { GrantName = GrantName, StudentId = StudentId, GrantValue = GrantValue });

            await _context.SaveChangesAsync();
            return View("Index");
        }

 

        // GET: GiftedGrants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftedGrant = await _context.GiftedGrants.FindAsync(id);
            if (giftedGrant == null)
            {
                return NotFound();
            }
            ViewData["GrantName"] = new SelectList(_context.GrantsInfos, "GrantName", "GrantName", giftedGrant.GrantName);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", giftedGrant.StudentId);
            return View(giftedGrant);
        }

        // POST: GiftedGrants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id,StudentId,GrantName,GrantValue")] GiftedGrant giftedGrant)
        {
            if (id != giftedGrant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giftedGrant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiftedGrantExists(giftedGrant.Id))
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
            ViewData["GrantName"] = new SelectList(_context.GrantsInfos, "GrantName", "GrantName", giftedGrant.GrantName);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id", giftedGrant.StudentId);
            return View(giftedGrant);
        }

        // GET: GiftedGrants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftedGrant = await _context.GiftedGrants
                .Include(g => g.GrantNameNavigation)
                .Include(g => g.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giftedGrant == null)
            {
                return NotFound();
            }

            return View(giftedGrant);
        }

        // POST: GiftedGrants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giftedGrant = await _context.GiftedGrants.FindAsync(id);
            if (giftedGrant != null)
            {
                _context.GiftedGrants.Remove(giftedGrant);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiftedGrantExists(int id)
        {
            return _context.GiftedGrants.Any(e => e.Id == id);
        }
    }
}
