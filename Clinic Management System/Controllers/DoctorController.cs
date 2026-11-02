using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Management_System.Controllers
{
    public class DoctorController : Controller
    {
      
            private readonly ApplicationDbContext _context;
            private readonly IWebHostEnvironment _webHostEnvironment;
            public DoctorController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
            {
                _context = context;
                _webHostEnvironment = webHostEnvironment;
            }
            public IActionResult Index()
            {
                var doctor = _context.doctors.Include(s => s.specialization).ToList();
                return View(doctor);
            }
            public IActionResult Create()
            {
            ViewBag.specialization = _context.specializations.ToList();
            return View();
            }
            [HttpPost]
            public IActionResult Create(Doctor doctor, IFormFile? imageFile)
            {
           

            if (!ModelState.IsValid)
                {
                ViewBag.specialization = _context.specializations.ToList();
                return View(doctor);
                }
                if (imageFile != null && imageFile.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images", "doctors");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }
                    string extension = Path.GetExtension(imageFile.FileName);
                    string uniqueFileName = Guid.NewGuid().ToString() + extension;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }
                    doctor.ImageUrl = uniqueFileName;
                }

                _context.doctors.Add(doctor);
                _context.SaveChanges();
                return RedirectToAction("index");
            }

            public IActionResult Edit(int id)
            {

            ViewBag.specialization = _context.specializations.ToList();
            var doctor = _context.doctors.FirstOrDefault(d => d.Id == id);
                if (doctor != null)
                {
                    return View(doctor);
                }
                else
                {
                    return NotFound();
                }
            }
            [HttpPost]
            public IActionResult Edit(Doctor doctor)
            {
                if (!ModelState.IsValid)
                {
                ViewBag.specialization = _context.specializations.ToList();
                return View(doctor);
                }
                var existingDoctor = _context.doctors.Find(doctor.Id);

                if (existingDoctor != null)
                {
                    existingDoctor.Name = doctor.Name;
                    existingDoctor.Phone = doctor.Phone;
                    existingDoctor.ConsultationFee = doctor.ConsultationFee;
                    existingDoctor.ImageUrl = doctor.ImageUrl;
                    existingDoctor.SpecializationId = doctor.SpecializationId;

                    _context.SaveChanges();
                    return RedirectToAction("index");
                }
                return NotFound();


            }
            public IActionResult Delete(int id)
            {
                var doctor = _context.doctors.Include(d => d.specialization).FirstOrDefault(d => d.Id == id);

                if (doctor != null)
                {
                    return View(doctor);
                }
                return NotFound();

            }
            [HttpPost, ActionName("Delete")]
            public IActionResult DeleteConfirmed(int id)
            {
                var doctor = _context.doctors.Include(d => d.specialization).FirstOrDefault(d => d.Id == id);
            if (doctor == null)
                {
                    return NotFound();

                }
                _context.doctors.Remove(doctor);
                _context.SaveChanges();
                return RedirectToAction("index");
            }

        }
}
