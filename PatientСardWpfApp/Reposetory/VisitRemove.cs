using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Models;
using System;
using System.Collections.ObjectModel;

namespace PatientСardWpfApp.Reposetory
{
    public class VisitRemove : IVisitRemover
    {
        public void DeletRecord(ref ObservableCollection<Visit> history, Visit record)
        {
            if (record != null)
                history.Remove(record);
            else
                throw new Exception("Ошибка удаления записи. Данные записи отсутствуют.");
        }
    }
}
