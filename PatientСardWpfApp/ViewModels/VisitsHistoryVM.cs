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
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System;

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

        private Visit _selectedRecord;
        private PersonalCard _patientCard;

        #region Public Properties
        public Visit SelectedRecord
        {
            get { return _selectedRecord; }
            set { SetProperty(ref _selectedRecord, value);
                  BtVisibility = (_selectedRecord != null) ? Visibility.Visible : Visibility.Hidden;
            }
        }

        private Visibility _btVisible = Visibility.Hidden;
        public Visibility BtVisibility
        {
            get { return _btVisible; }
            set { SetProperty(ref _btVisible, value); }
        }

        public static BindingList<Visit> PatientVisitsHistory { get; set; }

        IVisitRemover Remover { get; set; } = new VisitRemove();
        IDBLoader DBLoader { get; set; } = new DBDownload();

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
            RemoveRecordCommand = new DelegateCommand(RemoveRecord);
            EditRecordCommand = new DelegateCommand(EditRecord);

            HistoryListUpdate();
        }

        private void HistoryListUpdate()
        {
            App.dBContent.Visits.Load();
            PatientVisitsHistory = new BindingList<Visit>(App.dBContent.Visits.Local.Where(x => x.PatientId.Equals(_patientCard.Id)).ToList());
        }

        private void MakeRecord()
        {// Переход в редактор записей посещения:
         // Добавление новой записи.            
            SelectedRecord = new Visit(_patientCard.Id, DateTime.Now.Date, "", "");
            var vm = new VisitEditorVM();
            VisitEditorInit(vm);
            if (vm.isOK)
            {
                SelectedRecord = vm.curVisit;
                PatientVisitsHistory.Add(SelectedRecord);
            }
        }

        private void EditRecord()
        {// Переход в редактор записей посещения:
         // Изменение записи.            
            var vm = new VisitEditorVM(true);
            VisitEditorInit(vm);
        }

        private void RemoveRecord()
        {//Удаление записи
            if (MessageBox.Show("Удалить выбранную запись?",
                                "Подтвердите действие",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
            Remover.DeletRecord(SelectedRecord);
            PatientVisitsHistory.Remove(SelectedRecord);
        }

        private void VisitEditorInit(VisitEditorVM vm)
        {
            vm.curVisit = new Visit()
            {
                Id = SelectedRecord.Id,
                Date = SelectedRecord.Date,
                Type = SelectedRecord.Type,
                Diagnosis = SelectedRecord.Diagnosis,
                PatientId = SelectedRecord.PatientId
            };
            var EditorWindow = new VisitEditView()
            {
                DataContext = vm
            };
            vm.OnRequestClose += (s, e) => EditorWindow.Close();
            EditorWindow.ShowDialog();
        }
    }
}
