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
    public class GrantsInfoesController : Controller
    {
        private readonly Dz2Context _context;

        public GrantsInfoesController(Dz2Context context)
        {
            _context = context;
        }

        // GET: GrantsInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.GrantsInfos.ToListAsync());
        }

        // GET: GrantsInfoes/Details/5
       

        // GET: GrantsInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GrantsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GrantName,BanclorGrantValue,MasterGrantValue,AspirantGrantValue,GrantNameId")] GrantsInfo grantsInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grantsInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grantsInfo);
        }

        // GET: GrantsInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id== null)
            {
                return NotFound();
            }

            var grantsInfo = await _context.GrantsInfos.FindAsync(id);
            if (grantsInfo == null)
            {
                return NotFound();
            }
            return View(grantsInfo);
        }

        // POST: GrantsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GrantName,BanclorGrantValue,MasterGrantValue,AspirantGrantValue,GrantNameId")] GrantsInfo grantsInfo)
        {
            if (id!= grantsInfo.GrantName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grantsInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrantsInfoExists(grantsInfo.GrantName))
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
            return View(grantsInfo);
        }

        // GET: GrantsInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id== null)
            {
                return NotFound();
            }

            var grantsInfo = await _context.GrantsInfos
                .FirstOrDefaultAsync(m => m.GrantName == id);
            if (grantsInfo == null)
            {
                return NotFound();
            }

            return View(grantsInfo);
        }

        // POST: GrantsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var grantsInfo = await _context.GrantsInfos.FindAsync(id);
            if (grantsInfo != null)
            {
                _context.GrantsInfos.Remove(grantsInfo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrantsInfoExists(string id)
        {
            return _context.GrantsInfos.Any(e => e.GrantName == id);
        }
    }
}
