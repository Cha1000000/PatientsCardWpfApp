using PatientСardWpfApp.Interfaces;
using System.ComponentModel;
using System.Data.Entity;

namespace PatientСardWpfApp.Reposetory
{
    class DBDownload : IDBLoader
    {
        public IBindingList UpdateFromDB()
        {
            App.dBContent.PersonalCards.Load();
            return App.dBContent.PersonalCards.Local.ToBindingList();
        }
    }
}
