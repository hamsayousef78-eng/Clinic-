namespace Clinic_Management_System.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public enum Gender
        {
            Male,
            Female
        }
        public Gender PatientGender { get; set; }
        public List<Appointment>? appointments { get; set; }
    }
}
