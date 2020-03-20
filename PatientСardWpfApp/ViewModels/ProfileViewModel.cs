using PatientСardWpfApp.Models;
using PatientСardWpfApp.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;
using PatientСardWpfApp.Reposetory;

namespace PatientСardWpfApp.ViewModels
{
    class ProfileViewModel : BindableBase
    {
        public event EventHandler OnRequestClose;
        private bool IsEdit { get; set; }

        private IValidator Validator = new DataValidate();

        #region Public Properties

        private PersonalCard _patient;
        public PersonalCard Patient
        {
            get { return _patient; }
            set { SetProperty(ref _patient, value); }
        }

        #endregion

        #region Сохранить запись
        private DelegateCommand saveRecCommand;

        public ICommand SaveRecordCommand
        {
            get
            {
                if (saveRecCommand == null)
                {
                    if (!IsEdit)
                        saveRecCommand = new DelegateCommand(SaveNewRecord);
                    else
                        saveRecCommand = new DelegateCommand(SaveEditedRecord);
                }
                return saveRecCommand;
            }
        }

        private void SaveNewRecord()
        {
            if (Patient != null)
            {
                if (Validator.IsValid(Patient))
                {
                    App.dBContent.PersonalCards.Add(Patient);
                    App.dBContent.SaveChanges();
                }
                else return;
            }
            else
                MessageBox.Show("Ошибка сохранения записи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            OnRequestClose(this, new EventArgs());
        }

        private void SaveEditedRecord()
        {
            if (Patient != null)
            {
                if (Validator.IsValid(Patient))
                {
                    var p = App.dBContent.PersonalCards.Find(Patient.Id);
                    if (p != null)
                    {
                        p.Name = Patient.Name;
                        p.Surname = Patient.Surname;
                        p.Patronymic = Patient.Patronymic;
                        p.Sex = Patient.Sex;
                        p.Birthday = Patient.Birthday;
                        p.Phone = Patient.Phone;
                        p.Adress = Patient.Adress;
                        App.dBContent.Entry(p).State = EntityState.Modified;
                        App.dBContent.SaveChanges();
                    }
                }
                else return;
            }
            else
                MessageBox.Show("Ошибка сохранения записи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            OnRequestClose(this, new EventArgs());
        }
        #endregion

        public ProfileViewModel(PersonalCard patientData, bool isEdit = false)
        {            
            if (patientData != null)
                Patient = new PersonalCard()
                {
                    Id = patientData.Id,
                    Name = patientData.Name,
                    Surname = patientData.Surname,
                    Patronymic = patientData.Patronymic,
                    Sex = patientData.Sex,
                    Birthday = patientData.Birthday,
                    Phone = patientData.Phone,
                    Adress = patientData.Adress
                };
            else
                Patient = new PersonalCard();
            
            IsEdit = isEdit;
        }

    }
}
