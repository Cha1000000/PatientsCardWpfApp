using PatientСardWpfApp.Models;
using PatientСardWpfApp.Interfaces;
using Prism.Mvvm;
using System.Windows;
using System.ComponentModel;
using System.Windows.Input;
using PatientСardWpfApp.Views;
using Prism.Commands;
using System.Collections.ObjectModel;
using PatientСardWpfApp.Reposetory;

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
        private PersonalCard _patientCard;
        #region Public Properties
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

        public ObservableCollection<Visit> PatientVisitsHistory = new ObservableCollection<Visit>();

        public IVisitsAdder Adder { get; set; } = new VisitAdd();
        public IVisitRemover Remover { get; set; }

        public ICommand AddNewRecordCommand { get; private set; }
        public ICommand RemoveRecordCommand { get; private set; }
        public ICommand EditRecordCommand { get; private set; }
        #endregion

        //----------------------------------------------------------------------------------------------
        public VisitsHistoryVM(PersonalCard Patient)
        {
            if (Patient != null)
            {
                _patientCard = Patient;
                string FullName = string.Join(" ", Patient.Surname, Patient.Name, Patient.Patronymic);
                DisplayName += $": {FullName}";
            }

            AddNewRecordCommand = new DelegateCommand(MakeRecord);

            UpdateFromDB();
        }

        private void UpdateFromDB()
        {// Обновление информации в PatientVisitsHistory из БД

        }

        private void MakeRecord()
        {// Переход в редактор записей посещения
            if (_patientCard != null)
            {
                var VE = new VisitEditView();
                VE.DataContext = new VisitEditorVM(_patientCard);
                VE.ShowDialog();
                //Обновить PatientVisitsHistory из БД
            }
        }
    }
}
