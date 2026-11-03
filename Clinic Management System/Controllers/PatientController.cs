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
            
            var patient = _context.patients.Include(p => p.appointments).ToList();
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
        public IActionResult Details(int id)
        {
            var patient = _context.patients.Include(x => x.appointments).ThenInclude(x => x.doctor)
                             .ThenInclude(x => x.specialization).
                             FirstOrDefault(d => d.Id == id); 

            if (patient != null)
            {
                return View(patient);
            }
            else
            {
                return NotFound();
            }
        }

    }
}

