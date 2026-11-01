using Microsoft.EntityFrameworkCore;
namespace Clinic_Management_System.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> doctors { get; set; }

        public DbSet<Patient> patients { get; set; }
        public DbSet<Specialization> specializations { get; set; }
        public DbSet<Appointment> appointments { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
