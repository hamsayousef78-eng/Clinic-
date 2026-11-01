namespace Clinic_Management_System.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int ConsultationFee { get; set; }
        public string? ImageUrl { get; set; }
        public int SpecializationId { get; set; }//foreign key
        public List<Appointment>? appointments { get; set; }
    }
}
