using PatientСardWpfApp.Models;
using PatientСardWpfApp.Interfaces;
using System;
using System.Collections.ObjectModel;

namespace PatientСardWpfApp.Reposetory
{
    public class VisitAdd : IVisitsAdder
    {
        public Visit NewVisitRecord(int patientID, DateTime date, string type, string diag)
        {
            return new Visit { PatientId = patientID, Date = date, Type = type, Diagnosis = diag };
        }

        public void AddToHistory(ref ObservableCollection<Visit> visitsHistory, Visit record)
        {
            if (record != null)
            {
                visitsHistory.Add(record);
            }
            else
            {
                throw new Exception("Ошибка добавления новой записи. Данные записи отсутствуют.");
            }
        }

    }
}
