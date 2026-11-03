using Clinic_Management_System.Models;
using System.ComponentModel.DataAnnotations;
namespace Clinic_Management_System.ViewModels
{
    public class CreateAppoinmentViewModel
    {
        public int PatientId { get; set; }
        public int SpecializationId { get; set; }
        public int DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Notes { get; set; }
        public List<Patient>? patients { get; set; }
        public List<Doctor>? doctors { get; set; }
        public List<Specialization>? specializations { get; set; }
    }
}
