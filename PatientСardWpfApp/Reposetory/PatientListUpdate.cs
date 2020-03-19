using PatientСardWpfApp.Models;
using PatientСardWpfApp.Interfaces;
using System.ComponentModel;
using System.Data.Entity;

namespace PatientСardWpfApp.Reposetory
{
    public class PatientListUpdate : IContentUpdater
    {
        public IBindingList Update()
        {
            using (AppDBContent context = new AppDBContent())
            {
                context.PersonalCards.Load();
                return context.PersonalCards.Local.ToBindingList();
            }
        }
    }
}
