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
    public class statusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public statusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: status
        public async Task<IActionResult> Index()
        {
            return View(await _context.status.ToListAsync());
        }

        // GET: status/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.status
                .FirstOrDefaultAsync(m => m.id_status == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // GET: status/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_status,status_name")] status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: status/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.status.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: status/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_status,status_name")] status status)
        {
            if (id != status.id_status)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!statusExists(status.id_status))
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
            return View(status);
        }

        // GET: status/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.status
                .FirstOrDefaultAsync(m => m.id_status == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var status = await _context.status.FindAsync(id);
            if (status != null)
            {
                _context.status.Remove(status);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool statusExists(int id)
        {
            return _context.status.Any(e => e.id_status == id);
        }
    }
}
