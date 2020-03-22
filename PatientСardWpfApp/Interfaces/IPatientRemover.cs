using PatientСardWpfApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientСardWpfApp.Interfaces
{
    public interface IPatientRemover
    {
        void DeleteProfile(PersonalCard record);
    }
}
