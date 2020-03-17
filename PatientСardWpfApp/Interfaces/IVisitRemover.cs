using PatientСardWpfApp.Models;
using System.Collections.ObjectModel;

namespace PatientСardWpfApp.Interfaces
{
    public interface IVisitRemover
    {
        void DeletRecord(ref ObservableCollection<Visit> historyList, Visit record);
    }
}
