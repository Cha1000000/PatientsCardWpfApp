using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using PatientСardWpfApp.Models;
using PatientСardWpfApp.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace PatientСardWpfApp.ViewModels
{
    class MainWindowVM : BindableBase
    {
        #region property DisplayName
        /// <summary>
        /// Represent DisplayName property
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { SetProperty(ref _displayName, value); }
        }

        /// <summary>
        /// Backing field for property DisplayName
        /// </summary>
        private string _displayName = "Hospitalis Scrinium";

        #endregion

        private PersonalCard card;
        private PersonalCard _selectedPatient;
        private Visit visit;
        public PersonalCard Card
        {
            get { return card; }
            set { SetProperty(ref card, value); }
        }

        public Visit pVisit
        {
            get { return visit; }
            set { SetProperty(ref visit, value); }
        }

        public PersonalCard SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                SetProperty(ref _selectedPatient, value);
                BtVisibility = (_selectedPatient != null) ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private Visibility _btVisible = Visibility.Hidden;
        public Visibility BtVisibility
        {
            get { return _btVisible; }
            set { SetProperty(ref _btVisible, value); }
        }

        public static ObservableCollection<string> SexTypes { get; private set; } = new ObservableCollection<string>() { "Муж.", "Жен." };
        public ObservableCollection<PersonalCard> Patients { get; private set; }

        public ICommand NewPatientProfile { get; private set; }
        public ICommand ProfileRemove { get; private set; }
        public ICommand OpenProfile { get; private set; }
        public ICommand VisitsHistoryShow { get; private set; }
        //public DelegateCommand<object> VisitsHistoryShow { get; }

        public MainWindowVM()
        {
            Patients = new ObservableCollection<PersonalCard>();

            pVisit = new Visit(1, DateTime.Now, "Первичный", "Хронический бронхит");
            Card = new PersonalCard(1, "Иванов", "Иван", "Иванович", SexTypes[0], "15.03.1989", "+79191331239", "Курск, ул. Домосторителей, 1", pVisit);
            Patients.Add(Card);

            VisitsHistoryShow = new DelegateCommand(ShowVisitsHistoryView);
        }

        private void ShowVisitsHistoryView()
        {
            if (SelectedPatient != null)
            {
                var PHView = new PatientVisitsHistoryView();
                PHView.DataContext = new VisitsHistoryVM(SelectedPatient);                
                PHView.ShowDialog();
            }
            else
                throw new Exception("Невозможно отобразить данные. Укажите пациента из списка и повторите попытку.");            
        }

    }
}
