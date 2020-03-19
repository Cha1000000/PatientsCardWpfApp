using PatientСardWpfApp.Models;
using PatientСardWpfApp.Interfaces;
using System.ComponentModel;
using System.Data.Entity;

namespace PatientСardWpfApp.Reposetory
{
    public class VisitsHistoryUpdate : IContentUpdater
    {
        public IBindingList Update()
        {
            using (AppDBContent context = new AppDBContent())
            {
                context.Visits.Load();
                return context.PersonalCards.Local.ToBindingList();
            }
        }
    }
}
