namespace Clinic_Management_System.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

       public List<Doctor>? doctors { get; set; }
    }
}
