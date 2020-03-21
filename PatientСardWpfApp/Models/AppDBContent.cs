using System.Data.Entity;

namespace PatientСardWpfApp.Models
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(): base("DefaultConnection")
        {

        }

        public DbSet<Visit> Visits { get; set; }
        public DbSet<PersonalCard> PersonalCards { get; set; }

    }
}
