using PatientСardWpfApp.Models;
using System;
using System.Collections.ObjectModel;

namespace PatientСardWpfApp.Interfaces
{
    public interface IVisitsAdder
    {
        void NewVisitRecord(Visit visitData);
        void UpdateRecord(Visit visitData);
    }
}
