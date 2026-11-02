using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Management_System.Controllers
{
    public class SpecializationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SpecializationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var model = new SpecializationIndexViewModel
            {
                specializations = _context.specializations.Include(s=>s.doctors).ToList()
                
            };
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(SpecializationIndexViewModel model)
        {

            if (!ModelState.IsValid)
            {
                model.specializations= _context.specializations.ToList();
                return View("index");//هيخليني في نفس الصفحه ومفيش تخصص هيتضاف
            }
            _context.specializations.Add(model.NewSpecialization);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {

            var specialization = _context.specializations.FirstOrDefault(d => d.Id == id);
            if (specialization != null)
            {
                return View(specialization);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Edit(Specialization specialization)
        {
            if (!ModelState.IsValid)
            {

                return View(specialization);
            }
            var existingSpecialization = _context.specializations.Find(specialization.Id);

            if (existingSpecialization != null)
            {
                existingSpecialization.Name = specialization.Name;
                existingSpecialization.Description = specialization.Description;

                _context.SaveChanges();
                return RedirectToAction("index");
            }
            return NotFound();


        }
        public IActionResult Delete(int id)
        {
            var specialization = _context.specializations.FirstOrDefault(d => d.Id == id);

            if (specialization != null)
            {
                return View(specialization);
            }
            return NotFound();

        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var specialization = _context.specializations.Find(id);
            if (specialization == null)
            {
                return NotFound();

            }
            bool hasDoctors = _context.doctors.Any(doctor => doctor.SpecializationId == id);
            if (hasDoctors)//معناه انه التخصص ده فيه دكاتره
            {
                TempData["Error"] = "لا يمكن حذف التخصص لوجود دكاتره في هذا التخصص";
                return RedirectToAction("index");
            }
            _context.specializations.Remove(specialization);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }


}
