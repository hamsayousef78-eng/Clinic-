using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Management_System.Controllers
{
    public class PatientController : Controller
    {

        private readonly ApplicationDbContext _context;
        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var patient = _context.patients.ToList();
            return View(patient);
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Patient patient)
        {


            if (!ModelState.IsValid)
            {
                return View(patient);
            }
            _context.patients.Add(patient);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}

