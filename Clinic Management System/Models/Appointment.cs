namespace Clinic_Management_System.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Notes { get; set; }

        public enum Status
        {
            Pending ,
            Completed ,
            Cancelled
        }
        public Status? AppointmentStatus { get; set; }
        public int DoctorId { get; set; }//foreign key
        //Navigation
        public Doctor? doctor { get; set; } 
        public int PatientId { get; set; }//foreign key
        //Navigation
        public Patient? patient { get; set; } 

    }
}
