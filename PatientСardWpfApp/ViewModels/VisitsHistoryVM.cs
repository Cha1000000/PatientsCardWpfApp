using PatientСardWpfApp.Models;
using PatientСardWpfApp.Interfaces;
using Prism.Mvvm;
using System.Windows;
using System.ComponentModel;

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
        private Visit _selectedRecord;
        public Visit Visit
        {
            get { return visit; }
            set { SetProperty(ref visit, value); }
        }
         public Visit SelectedRecord
        {
            get { return _selectedRecord; }
            set { SetProperty(ref _selectedRecord, value); }
        }

        private Visibility _btVisible = Visibility.Hidden;
        public Visibility BtVisibility
        {
            get { return _btVisible; }
            set { SetProperty(ref _btVisible, value); }
        }

        public BindingList<Visit> PatientVisitsHistory = new BindingList<Visit>();

        public IVisitsAdder Adder { get; set; }
        public IVisitRemover Remover { get; set; }

        public VisitsHistoryVM(PersonalCard Patient)
        {
            if (Patient != null)
            {
                string FullName = string.Join(" ", Patient.Surname, Patient.Name, Patient.Patronymic);
                DisplayName += $": {FullName}";
            }

            //Загрузить данные из БД, соответственно id пациента, в PatientVisitsHistory
        }


    }
}
