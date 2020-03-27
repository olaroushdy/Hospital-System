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
    public class EmployeeRolesController : Controller
    {
        private readonly HospitalContext _context;

        public EmployeeRolesController(HospitalContext context)
        {
            _context = context;
        }

        // GET: EmployeeRoles
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.EmployeeRoles.Include(e => e.Employee).Include(e => e.PatientType);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: EmployeeRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles
                .Include(e => e.Employee)
                .Include(e => e.PatientType)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeRole == null)
            {
                return NotFound();
            }

            return View(employeeRole);
        }

        // GET: EmployeeRoles/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
            ViewData["PatientTypeId"] = new SelectList(_context.PatientTypes, "PatientTypeId", "PatientTypeId");
            return View();
        }

        // POST: EmployeeRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,PatientTypeId")] EmployeeRole employeeRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeeRole.EmployeeId);
            ViewData["PatientTypeId"] = new SelectList(_context.PatientTypes, "PatientTypeId", "PatientTypeId", employeeRole.PatientTypeId);
            return View(employeeRole);
        }

        // GET: EmployeeRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles.FindAsync(id);
            if (employeeRole == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeeRole.EmployeeId);
            ViewData["PatientTypeId"] = new SelectList(_context.PatientTypes, "PatientTypeId", "PatientTypeId", employeeRole.PatientTypeId);
            return View(employeeRole);
        }

        // POST: EmployeeRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,PatientTypeId")] EmployeeRole employeeRole)
        {
            if (id != employeeRole.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeRoleExists(employeeRole.EmployeeId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId", employeeRole.EmployeeId);
            ViewData["PatientTypeId"] = new SelectList(_context.PatientTypes, "PatientTypeId", "PatientTypeId", employeeRole.PatientTypeId);
            return View(employeeRole);
        }

        // GET: EmployeeRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeRole = await _context.EmployeeRoles
                .Include(e => e.Employee)
                .Include(e => e.PatientType)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeRole == null)
            {
                return NotFound();
            }

            return View(employeeRole);
        }

        // POST: EmployeeRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeRole = await _context.EmployeeRoles.FindAsync(id);
            _context.EmployeeRoles.Remove(employeeRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeRoleExists(int id)
        {
            return _context.EmployeeRoles.Any(e => e.EmployeeId == id);
        }
    }
}
