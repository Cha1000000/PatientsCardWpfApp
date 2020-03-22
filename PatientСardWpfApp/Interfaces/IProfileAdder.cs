using PatientСardWpfApp.Models;

namespace PatientСardWpfApp.Interfaces
{
    public interface IProfileAdder
    {
        void SaveNewProfile(PersonalCard patientData);
        void UpdateRecord(PersonalCard patientData);
    }
}
