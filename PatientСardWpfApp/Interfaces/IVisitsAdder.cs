using PatientСardWpfApp.Models;
using System;
using System.Collections.ObjectModel;

namespace PatientСardWpfApp.Interfaces
{
    public interface IVisitsAdder
    {
        Visit NewVisitRecord(int patientID, DateTime date, string type, string diag);
        void AddToHistory(ref ObservableCollection<Visit> visitsHistory, Visit record);
    }
}
