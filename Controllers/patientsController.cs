using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using clinica2.Data;
using clinica2.Models;
using System.Security.Claims;

namespace clinica2.Controllers
{
    public class patientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public patientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: patients
        public async Task<IActionResult> Index()
        {
            int? userRole = null;
            if (User.Identity.IsAuthenticated)
            {
                var roleClaim = User.FindFirst(ClaimTypes.Role);
                if (roleClaim != null && int.TryParse(roleClaim.Value, out int parsedRole))
                {
                    userRole = parsedRole;
                }
            }
            ViewData["UserRole"] = userRole;

            var patients = _context.patients
                .Include(p => p.roles)
                .Include(p => p.site);

            return View(await patients.ToListAsync());
        }

        // GET: patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.patients
                .Include(p => p.roles)
                .Include(p => p.site)
                .FirstOrDefaultAsync(m => m.id_patient == id);
            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        // GET: patients/Create
        public IActionResult Create()
        {
            ViewData["id_role"] = new SelectList(_context.roles, "id_role", "role_name");
            ViewData["id_site"] = new SelectList(_context.site, "id_site", "site_number");
            return View();
        }

        // POST: patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_patient,first_name,last_name,middle_name,date_of_birth,gender,policy_number,telephone,login,password,id_site,id_role")] patients patients)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patients);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_role"] = new SelectList(_context.roles, "id_role", "role_name", patients.id_role);
            ViewData["id_site"] = new SelectList(_context.site, "id_site", "site_number", patients.id_site);
            return View(patients);
        }

        // GET: patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.patients.FindAsync(id);
            if (patients == null)
            {
                return NotFound();
            }
            ViewData["id_role"] = new SelectList(_context.roles, "id_role", "role_name", patients.id_role);
            ViewData["id_site"] = new SelectList(_context.site, "id_site", "site_number", patients.id_site);
            return View(patients);
        }

        // POST: patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_patient,first_name,last_name,middle_name,date_of_birth,gender,policy_number,telephone,login,password,id_site,id_role")] patients patients)
        {
            if (id != patients.id_patient)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patients);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!patientsExists(patients.id_patient))
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
            ViewData["id_role"] = new SelectList(_context.roles, "id_role", "role_name", patients.id_role);
            ViewData["id_site"] = new SelectList(_context.site, "id_site", "site_number", patients.id_site);
            return View(patients);
        }

        // GET: patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.patients
                .Include(p => p.roles)
                .Include(p => p.site)
                .FirstOrDefaultAsync(m => m.id_patient == id);
            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        // POST: patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patients = await _context.patients.FindAsync(id);
            if (patients != null)
            {
                _context.patients.Remove(patients);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool patientsExists(int id)
        {
            return _context.patients.Any(e => e.id_patient == id);
        }
    }
}
