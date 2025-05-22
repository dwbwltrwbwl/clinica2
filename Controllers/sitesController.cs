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
    public class sitesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public sitesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: sites
        public async Task<IActionResult> Index()
        {
            return View(await _context.site.ToListAsync());
        }

        // GET: sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.site
                .FirstOrDefaultAsync(m => m.id_site == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: sites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: sites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_site,site_number")] site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.site.FindAsync(id);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // POST: sites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_site,site_number")] site site)
        {
            if (id != site.id_site)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!siteExists(site.id_site))
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
            return View(site);
        }

        // GET: sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.site
                .FirstOrDefaultAsync(m => m.id_site == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var site = await _context.site.FindAsync(id);
            if (site != null)
            {
                _context.site.Remove(site);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool siteExists(int id)
        {
            return _context.site.Any(e => e.id_site == id);
        }
    }
}
