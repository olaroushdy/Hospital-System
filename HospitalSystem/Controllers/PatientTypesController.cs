using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalSystem;
using HospitalSystem.Models;

namespace HospitalSystem.Controllers
{
    public class PatientTypesController : Controller
    {
        private readonly HospitalContext _context;

        public PatientTypesController(HospitalContext context)
        {
            _context = context;
        }

        // GET: PatientTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PatientTypes.ToListAsync());
        }

        // GET: PatientTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientType = await _context.PatientTypes
                .FirstOrDefaultAsync(m => m.PatientTypeId == id);
            if (patientType == null)
            {
                return NotFound();
            }

            return View(patientType);
        }

        // GET: PatientTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PatientTypeId,Name")] PatientType patientType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientType);
        }

        // GET: PatientTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientType = await _context.PatientTypes.FindAsync(id);
            if (patientType == null)
            {
                return NotFound();
            }
            return View(patientType);
        }

        // POST: PatientTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PatientTypeId,Name")] PatientType patientType)
        {
            if (id != patientType.PatientTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientTypeExists(patientType.PatientTypeId))
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
            return View(patientType);
        }

        // GET: PatientTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientType = await _context.PatientTypes
                .FirstOrDefaultAsync(m => m.PatientTypeId == id);
            if (patientType == null)
            {
                return NotFound();
            }

            return View(patientType);
        }

        // POST: PatientTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientType = await _context.PatientTypes.FindAsync(id);
            _context.PatientTypes.Remove(patientType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientTypeExists(int id)
        {
            return _context.PatientTypes.Any(e => e.PatientTypeId == id);
        }
    }
}
