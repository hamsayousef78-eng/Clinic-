using Clinic_Management_System.Models;
using Clinic_Management_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Management_System.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            var model = new CreateAppoinmentViewModel
            {
                patients = _context.patients.ToList(),
                 doctors = _context.doctors.ToList(),
                  specializations = _context.specializations.ToList()
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CreateAppoinmentViewModel model)
        {

            if (!ModelState.IsValid)
               
            {
                return View(model);
            }
            var appointment = new Appointment
            {
                PatientId = model.PatientId,
                DoctorId = model.DoctorId,
                AppointmentDate = model.AppointmentDate,
                Notes = model.Notes
            };

            _context.appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
    }

