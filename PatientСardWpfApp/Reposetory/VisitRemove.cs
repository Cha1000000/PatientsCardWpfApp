using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Models;
using System.Linq;

namespace PatientСardWpfApp.Reposetory
{
    public class VisitRemove : IVisitRemover
    {
        public void DeletRecord(Visit record)
        {
            if (record != null)
            {
                var temp = App.dBContent.Visits.ToList();
                var selecteditem = from t in App.dBContent.Visits
                                   where t.Id == record.Id
                                   select t;
                App.dBContent.Visits.Remove(selecteditem.FirstOrDefault());
                App.dBContent.SaveChanges();
            }
        }
    }
}
