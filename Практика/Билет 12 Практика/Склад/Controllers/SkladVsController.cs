using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Въвеждане_на_продукти_в_склад_НОВ.Models;

namespace Въвеждане_на_продукти_в_склад_НОВ.Controllers
{
    public class SkladVsController : Controller
    {
        private readonly vdatabaseContext _context;

        public SkladVsController(vdatabaseContext context)
        {
            _context = context;
        }

        // GET: SkladVs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SkladVs.ToListAsync());
        }

        // GET: SkladVs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladV = await _context.SkladVs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skladV == null)
            {
                return NotFound();
            }

            return View(skladV);
        }

        // GET: SkladVs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkladVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Price,Count")] SkladV skladV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skladV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skladV);
        }

        // GET: SkladVs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladV = await _context.SkladVs.FindAsync(id);
            if (skladV == null)
            {
                return NotFound();
            }
            return View(skladV);
        }

        // POST: SkladVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Price,Count")] SkladV skladV)
        {
            if (id != skladV.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skladV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkladVExists(skladV.Id))
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
            return View(skladV);
        }

        // GET: SkladVs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladV = await _context.SkladVs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skladV == null)
            {
                return NotFound();
            }

            return View(skladV);
        }

        // POST: SkladVs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skladV = await _context.SkladVs.FindAsync(id);
            _context.SkladVs.Remove(skladV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkladVExists(int id)
        {
            return _context.SkladVs.Any(e => e.Id == id);
        }
    }
}
