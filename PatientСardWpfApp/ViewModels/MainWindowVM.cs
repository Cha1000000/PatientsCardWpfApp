using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Windows;
using PatientСardWpfApp.Models;
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
        private Visit visit;
        public PersonalCard Card {
            get { return card; }
            set { SetProperty(ref card, value); }
        }

        public Visit pVisit {
            get { return visit; }
            set { SetProperty(ref visit, value); }
        }

        private PersonalCard _selectedPatient;
        public PersonalCard SelectedPatient {
            get { return _selectedPatient; }
            set { SetProperty(ref _selectedPatient, value); }
        }

        private Visibility _btVisible = Visibility.Hidden;
        public Visibility BtVisibility {
            get { return _btVisible; }
            set { SetProperty(ref _btVisible, value); }
        }

        public static ObservableCollection<string> SexTypes { get; private set; } = new ObservableCollection<string>() { "Муж.", "Жен." };
        public ObservableCollection<PersonalCard> Patients { get; private set; }

        public MainWindowVM()
        {                        
            Patients = new ObservableCollection<PersonalCard>();

            pVisit = new Visit(1, DateTime.Now, "Первичный", "Хронический бронхит");
            Card = new PersonalCard(1, "Иванов", "Иван", "Иванович", SexTypes[0], "15.03.1989", "+79191331239", "Курск, ул. Домосторителей, 1", pVisit);            
            Patients.Add(Card);
        }
    }
}
