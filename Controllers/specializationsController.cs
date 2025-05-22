using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clinica2.Data;
using clinica2.Models;

namespace clinica2.Controllers
{
    public class specializationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public specializationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: specializations
        public async Task<IActionResult> Index()
        {
            return View(await _context.specializations.ToListAsync());
        }

        // GET: specializations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specializations = await _context.specializations
                .FirstOrDefaultAsync(m => m.id_specialization == id);
            if (specializations == null)
            {
                return NotFound();
            }

            return View(specializations);
        }

        // GET: specializations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: specializations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_specialization,specialization_name")] specializations specializations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specializations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specializations);
        }

        // GET: specializations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specializations = await _context.specializations.FindAsync(id);
            if (specializations == null)
            {
                return NotFound();
            }
            return View(specializations);
        }

        // POST: specializations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_specialization,specialization_name")] specializations specializations)
        {
            if (id != specializations.id_specialization)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specializations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!specializationsExists(specializations.id_specialization))
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
            return View(specializations);
        }

        // GET: specializations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specializations = await _context.specializations
                .FirstOrDefaultAsync(m => m.id_specialization == id);
            if (specializations == null)
            {
                return NotFound();
            }

            return View(specializations);
        }

        // POST: specializations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specializations = await _context.specializations.FindAsync(id);
            if (specializations != null)
            {
                _context.specializations.Remove(specializations);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool specializationsExists(int id)
        {
            return _context.specializations.Any(e => e.id_specialization == id);
        }
    }
}
