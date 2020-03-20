using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
