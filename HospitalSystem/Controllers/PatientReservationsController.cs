using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalSystem;
using HospitalSystem.Models;
using HospitalSystem.ViewModel;
using Microsoft.AspNetCore.Http;
using HospitalSystem.Helper;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace HospitalSystem.Controllers
{
    public class PatientReservationsController : Controller
    {
        private readonly HospitalContext _context;
        private readonly IConfiguration _configuration;

        public PatientReservationsController(HospitalContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: PatientReservations
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.PatientReservations.Include(p => p.Employee).Include(p => p.PatientHistory).Include(p => p.PatientType);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: PatientReservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientReservation = await _context.PatientReservations
                .Include(p => p.Employee)
                .Include(p => p.PatientHistory)
                .Include(p => p.PatientType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientReservation == null)
            {
                return NotFound();
            }

            return View(patientReservation);
        }
        [HttpPost]
        public ActionResult Attach(IFormFile file)
        {
            if (file != null && file.Length > 0)
                try
                {
                    var contentBytes = new byte[file.Length];
                    file.OpenReadStream().Read(contentBytes, 0, contentBytes.Length);
                    var attachfile = UploadFile(file.FileName, contentBytes);
                    if (attachfile != null)
                        TempData["NationalId"] = attachfile;
                    ViewBag.Message = "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }
        public async Task<AttachFile> UploadFile(string fileName, byte[] fileContent)
        {
            var rootDirPath = _configuration.GetValue<string>("AttachmentFilesPhysicalPath");

            var filePath = $"{Guid.NewGuid()}_{fileName}";

            var filePhysicalPath = Path.Combine(rootDirPath, filePath.Trim('/'));
            
            await System.IO.File.WriteAllBytesAsync(filePhysicalPath, fileContent);
            return new AttachFile { FileName = fileName, FilePath = filePath };

         }

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            // Extract file name from whatever was posted by browser
            var fileName = System.IO.Path.GetFileName(file.FileName);

            // If file with same name exists delete it
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

            // Create new local file and copy contents of uploaded file
            using (var localFile = System.IO.File.OpenWrite(fileName))
            using (var uploadedFile = file.OpenReadStream())
            {
                uploadedFile.CopyTo(localFile);
            }

            ViewBag.Message = "File successfully uploaded";

            return View();
        }
        // GET: PatientReservations/Create
        public IActionResult Create()
        {
            var patientTypes = _context.PatientTypes.ToList();
             ViewBag.PatientType = patientTypes;

            return View();
        }

        // POST: PatientReservations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientReservation patientReservation)
        {
            patientReservation.EmployeeId = 1;
            patientReservation.CreatedDate = DateTime.Now;
            patientReservation.FildeId = GenerateFileId();
            var attachFile = TempData["NationalId"] as AttachFile;
            if(attachFile != null)
               patientReservation.NationalId = attachFile.FilePath;
            _context.Add(patientReservation);
            await _context.SaveChangesAsync();
           return  RedirectToAction(nameof(Index));

        }

        private string GenerateFileId()
        {
            var lastPatient = _context.PatientReservations.OrderByDescending(x => x.Id).FirstOrDefault();
            var currentDate = DateTime.Now.ToString("yyyyddMM");
            if (lastPatient == null )
                return currentDate + ("0001");

            var fileId = int.Parse(lastPatient.FildeId.Substring(8, 4));
            var currentFieldId = ++fileId;
            return currentDate + currentFieldId.ToString("D4");

        }

        // GET: PatientReservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientReservation = await _context.PatientReservations.FindAsync(id);
            var patientTypes = _context.PatientTypes.ToList();
            if (patientReservation == null)
            {
                return NotFound();
            }
            ViewBag.PatientType = patientTypes;
            return View(patientReservation);
        }

        // POST: PatientReservations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PatientReservation patientReservation)
        {
            if (id != patientReservation.Id)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(patientReservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientReservationExists(patientReservation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            var patientTypes = _context.PatientTypes.ToList();
            ViewBag.PatientType = patientTypes;
            return View(patientReservation);
        }

        // GET: PatientReservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientReservation = await _context.PatientReservations
                .Include(p => p.Employee)
                .Include(p => p.PatientHistory)
                .Include(p => p.PatientType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patientReservation == null)
            {
                return NotFound();
            }

            return View(patientReservation);
        }

        // POST: PatientReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientReservation = await _context.PatientReservations.FindAsync(id);
            _context.PatientReservations.Remove(patientReservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientReservationExists(int id)
        {
            return _context.PatientReservations.Any(e => e.Id == id);
        }
    }
}
