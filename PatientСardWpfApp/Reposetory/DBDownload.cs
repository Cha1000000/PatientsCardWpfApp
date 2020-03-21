using System.ComponentModel;
using System.Data.Entity;
using PatientСardWpfApp.Interfaces;

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
