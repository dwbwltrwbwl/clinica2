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
    public class doctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public doctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: doctors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.doctors.Include(d => d.roles).Include(d => d.specializations);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.doctors
                .Include(d => d.roles)
                .Include(d => d.specializations)
                .FirstOrDefaultAsync(m => m.id_doctor == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // GET: doctors/Create
        public IActionResult Create()
        {
            ViewData["id_role"] = new SelectList(_context.roles, "id_role", "role_name");
            ViewData["id_specialization"] = new SelectList(_context.specializations, "id_specialization", "specialization_name");
            return View();
        }

        // POST: doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_doctor,first_name,last_name,middle_name,telephone,login,password,image,id_specialization,id_role")] doctors doctors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_role"] = new SelectList(_context.roles, "id_role", "role_name", doctors.id_role);
            ViewData["id_specialization"] = new SelectList(_context.specializations, "id_specialization", "specialization_name", doctors.id_specialization);
            return View(doctors);
        }

        // GET: doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.doctors.FindAsync(id);
            if (doctors == null)
            {
                return NotFound();
            }
            ViewData["id_role"] = new SelectList(_context.roles, "id_role", "role_name", doctors.id_role);
            ViewData["id_specialization"] = new SelectList(_context.specializations, "id_specialization", "specialization_name", doctors.id_specialization);
            return View(doctors);
        }

        // POST: doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_doctor,first_name,last_name,middle_name,telephone,login,password,image,id_specialization,id_role")] doctors doctors)
        {
            if (id != doctors.id_doctor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!doctorsExists(doctors.id_doctor))
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
            ViewData["id_role"] = new SelectList(_context.roles, "id_role", "role_name", doctors.id_role);
            ViewData["id_specialization"] = new SelectList(_context.specializations, "id_specialization", "specialization_name", doctors.id_specialization);
            return View(doctors);
        }

        // GET: doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctors = await _context.doctors
                .Include(d => d.roles)
                .Include(d => d.specializations)
                .FirstOrDefaultAsync(m => m.id_doctor == id);
            if (doctors == null)
            {
                return NotFound();
            }

            return View(doctors);
        }

        // POST: doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctors = await _context.doctors.FindAsync(id);
            if (doctors != null)
            {
                _context.doctors.Remove(doctors);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool doctorsExists(int id)
        {
            return _context.doctors.Any(e => e.id_doctor == id);
        }
    }
}
