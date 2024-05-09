using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task_.Models;

namespace Task_.Controllers
{
    public class VtaskController : Controller
    {
        private readonly VTaskContext _context;

        public VtaskController(VTaskContext context)
        {
            _context = context;
        }

        // GET: Vtask
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vtasks.ToListAsync());
        }

        // GET: Vtask/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vtask = await _context.Vtasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vtask == null)
            {
                return NotFound();
            }

            return View(vtask);
        }

        // GET: Vtask/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vtask/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Status")] Vtask vtask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vtask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vtask);
        }

        // GET: Vtask/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vtask = await _context.Vtasks.FindAsync(id);
            if (vtask == null)
            {
                return NotFound();
            }
            return View(vtask);
        }

        // POST: Vtask/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Status")] Vtask vtask)
        {
            if (id != vtask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vtask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VtaskExists(vtask.Id))
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
            return View(vtask);
        }

        // GET: Vtask/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vtask = await _context.Vtasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vtask == null)
            {
                return NotFound();
            }

            return View(vtask);
        }

        // POST: Vtask/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vtask = await _context.Vtasks.FindAsync(id);
            _context.Vtasks.Remove(vtask);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VtaskExists(int id)
        {
            return _context.Vtasks.Any(e => e.Id == id);
        }
    }
}
