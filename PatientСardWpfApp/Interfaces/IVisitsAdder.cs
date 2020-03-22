using PatientСardWpfApp.Models;

namespace PatientСardWpfApp.Interfaces
{
    public interface IVisitsAdder
    {
        void NewVisitRecord(Visit visitData);
        void UpdateRecord(Visit visitData);
    }
}
