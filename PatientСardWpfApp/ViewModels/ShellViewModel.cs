using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Models;
using PatientСardWpfApp.Reposetory;
using PatientСardWpfApp.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace PatientСardWpfApp.ViewModels
{
    class ShellViewModel : BindableBase
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
        private string _stateInfo;

        #region Public Properties
        public PersonalCard Card
        {
            get { return card; }
            set { SetProperty(ref card, value); }
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

        public string StateInfo
        {
            get { return _stateInfo; }
            set { SetProperty(ref _stateInfo, value); }
        }

        private Visibility _btVisible = Visibility.Hidden;
        public Visibility BtVisibility
        {
            get { return _btVisible; }
            set { SetProperty(ref _btVisible, value); }
        }

        public static BindingList<string> SexTypes { get; private set; } = new BindingList<string>() { "Муж.", "Жен." };
        public static BindingList<PersonalCard> Patients { get; set; }
        IDBLoader DBLoader { get; set; } = new DBDownload();
        public ICommand NewPatientProfile { get; private set; }
        public ICommand ProfileRemove { get; private set; }
        public ICommand OpenProfile { get; private set; }
        public ICommand VisitsHistoryShow { get; private set; }

        #endregion

        public ShellViewModel()
        {            
            VisitsHistoryShow = new DelegateCommand(ShowVisitsHistoryView);
            NewPatientProfile = new DelegateCommand(NewProfile);
            ProfileRemove = new DelegateCommand(RemoveProfile);
            OpenProfile = new DelegateCommand(EditProfile);

            Patients = new BindingList<PersonalCard>();
            Patients = (BindingList<PersonalCard>)DBLoader.UpdateFromDB();
        }

        private void NewProfile()
        {
            var vm = new ProfileViewModel(null);
            var ProfileWin = new ProfileView
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => ProfileWin.Close();
            ProfileWin.ShowDialog();
        }

        private void EditProfile()
        {
            if (_selectedPatient != null)
            {
                var vm = new ProfileViewModel(SelectedPatient, true);
                var ProfileWin = new ProfileView
                {
                    DataContext = vm
                };
                vm.OnRequestClose += (s, e) => ProfileWin.Close();
                ProfileWin.ShowDialog();
            }
        }

        private void RemoveProfile()
        {
            if (MessageBox.Show("Удалить запись выбранного пациента?",
                                "Подтвердите действие",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
                if (SelectedPatient != null)
                {
                    List<PersonalCard> temp = App.dBContent.PersonalCards.ToList();
                    var selecteditem = from t in App.dBContent.PersonalCards
                                       where SelectedPatient.Id == t.Id
                                       select t;
                    App.dBContent.PersonalCards.Remove(selecteditem.FirstOrDefault());
                    App.dBContent.SaveChanges();
                }
        }

        private void ShowVisitsHistoryView()
        {
            if (SelectedPatient != null)
            {
                var VisitsWindow = new VisitsHistoryView();
                VisitsWindow.DataContext = new VisitsHistoryVM(SelectedPatient);
                VisitsWindow.ShowDialog();
            }
            else
                return;
        }
        
    }
}
