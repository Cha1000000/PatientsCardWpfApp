using PatientСardWpfApp.Models;
using PatientСardWpfApp.Interfaces;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientСardWpfApp.ViewModels
{
    class VisitsHistoryVM : BindableBase
    {
        #region property DisplayName
        private string _displayName = "История посещений пациента";

        public string DisplayName
        {
            get { return _displayName; }
            set { SetProperty(ref _displayName, value); }
        }
        #endregion

        private Visit visit;

        public Visit Visit
        {
            get { return visit; }
            set { SetProperty(ref visit, value); }
        }

        public ObservableCollection<Visit> PatientVisitsHistory = new ObservableCollection<Visit>();

        public IVisitsAdder Adder { get; set; }
        public IVisitRemover Remover { get; set; }

        public VisitsHistoryVM(PersonalCard Patient)
        {
            if (Patient != null)
            {
                string FullName = string.Join(" ", Patient.Surname, Patient.Name, Patient.Patronymic);
                DisplayName += $": {FullName}";
            }
        }


    }
}
