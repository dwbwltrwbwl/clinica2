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
    public class receptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public receptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: receptions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.receptions.Include(r => r.diagnosis).Include(r => r.doctors).Include(r => r.patients).Include(r => r.status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: receptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receptions = await _context.receptions
                .Include(r => r.diagnosis)
                .Include(r => r.doctors)
                .Include(r => r.patients)
                .Include(r => r.status)
                .FirstOrDefaultAsync(m => m.id_reception == id);
            if (receptions == null)
            {
                return NotFound();
            }

            return View(receptions);
        }

        // GET: receptions/Create
        public IActionResult Create()
        {
            // Формируем список пациентов с ФИО
            var patients = _context.patients
                .ToList()
                .Select(p => new
                {
                    id_patient = p.id_patient,
                    FullName = $"{p.first_name} {p.last_name} {p.middle_name ?? ""}".TrimEnd()
                });
            ViewData["id_patient"] = new SelectList(patients, "id_patient", "FullName");

            // Формируем список врачей с ФИО
            var doctors = _context.doctors
                .ToList()
                .Select(d => new
                {
                    id_doctor = d.id_doctor,
                    FullName = $"{d.first_name} {d.last_name} {d.middle_name ?? ""}".TrimEnd()
                });
            ViewData["id_doctor"] = new SelectList(doctors, "id_doctor", "FullName");

            ViewData["id_diagnosis"] = new SelectList(_context.diagnosis, "id_diagnosis", "diagnosis_name");
            ViewData["id_status"] = new SelectList(_context.status, "id_status", "status_name");
            return View();
        }

        // POST: receptions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_reception,date_reception,time_reception,id_patient,id_doctor,id_status,symptoms,id_diagnosis,treatment")] receptions receptions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receptions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var patients = _context.patients
                .ToList()
                .Select(p => new
                {
                    id_patient = p.id_patient,
                    FullName = $"{p.first_name} {p.last_name} {p.middle_name ?? ""}".TrimEnd()
                });
            ViewData["id_patient"] = new SelectList(patients, "id_patient", "FullName", receptions.id_patient);

            var doctors = _context.doctors
                .ToList()
                .Select(d => new
                {
                    id_doctor = d.id_doctor,
                    FullName = $"{d.first_name} {d.last_name} {d.middle_name ?? ""}".TrimEnd()
                });
            ViewData["id_doctor"] = new SelectList(doctors, "id_doctor", "FullName", receptions.id_doctor);

            ViewData["id_diagnosis"] = new SelectList(_context.diagnosis, "id_diagnosis", "diagnosis_name", receptions.id_diagnosis);
            ViewData["id_status"] = new SelectList(_context.status, "id_status", "status_name", receptions.id_status);
            return View(receptions);
        }

        // GET: receptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receptions = await _context.receptions.FindAsync(id);
            if (receptions == null)
            {
                return NotFound();
            }

            var patients = _context.patients
                .ToList()
                .Select(p => new
                {
                    id_patient = p.id_patient,
                    FullName = $"{p.first_name} {p.last_name} {p.middle_name ?? ""}".TrimEnd()
                });
            ViewData["id_patient"] = new SelectList(patients, "id_patient", "FullName", receptions.id_patient);

            var doctors = _context.doctors
                .ToList()
                .Select(d => new
                {
                    id_doctor = d.id_doctor,
                    FullName = $"{d.first_name} {d.last_name} {d.middle_name ?? ""}".TrimEnd()
                });
            ViewData["id_doctor"] = new SelectList(doctors, "id_doctor", "FullName", receptions.id_doctor);

            ViewData["id_diagnosis"] = new SelectList(_context.diagnosis, "id_diagnosis", "diagnosis_name", receptions.id_diagnosis);
            ViewData["id_status"] = new SelectList(_context.status, "id_status", "status_name", receptions.id_status);
            return View(receptions);
        }

        // POST: receptions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_reception,date_reception,time_reception,id_patient,id_doctor,id_status,symptoms,id_diagnosis,treatment")] receptions receptions)
        {
            if (id != receptions.id_reception)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receptions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!receptionsExists(receptions.id_reception))
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

            var patients = _context.patients
        .ToList()
        .Select(p => new
        {
            id_patient = p.id_patient,
            FullName = $"{p.first_name} {p.last_name} {p.middle_name ?? ""}".TrimEnd()
        });
            ViewData["id_patient"] = new SelectList(patients, "id_patient", "FullName", receptions.id_patient);

            var doctors = _context.doctors
                .ToList()
                .Select(d => new
                {
                    id_doctor = d.id_doctor,
                    FullName = $"{d.first_name} {d.last_name} {d.middle_name ?? ""}".TrimEnd()
                });
            ViewData["id_doctor"] = new SelectList(doctors, "id_doctor", "FullName", receptions.id_doctor);

            ViewData["id_diagnosis"] = new SelectList(_context.diagnosis, "id_diagnosis", "diagnosis_name", receptions.id_diagnosis);
            ViewData["id_status"] = new SelectList(_context.status, "id_status", "status_name", receptions.id_status);
            return View(receptions);
        }

        // GET: receptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receptions = await _context.receptions
                .Include(r => r.diagnosis)
                .Include(r => r.doctors)
                .Include(r => r.patients)
                .Include(r => r.status)
                .FirstOrDefaultAsync(m => m.id_reception == id);
            if (receptions == null)
            {
                return NotFound();
            }

            return View(receptions);
        }

        // POST: receptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receptions = await _context.receptions.FindAsync(id);
            if (receptions != null)
            {
                _context.receptions.Remove(receptions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool receptionsExists(int id)
        {
            return _context.receptions.Any(e => e.id_reception == id);
        }
    }
}
