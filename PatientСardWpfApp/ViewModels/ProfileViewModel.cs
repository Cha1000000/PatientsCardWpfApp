using PatientСardWpfApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Windows;
using System.Windows.Input;

namespace PatientСardWpfApp.ViewModels
{
    class ProfileViewModel : BindableBase
    {
        public event EventHandler OnRequestClose;
        private bool IsEdit { get; set; }

        #region Public Properties

        private PersonalCard _patient;
        public PersonalCard Patient
        {
            get { return _patient; }
            set { SetProperty(ref _patient, value); }
        }

        /*
        private string _sur;
        public string Surname
        {
            get { return Patient.Surname ?? _sur; }
            set
            {
                Patient.Surname = value;
                SetProperty(ref _sur, value);
            }
        }

        private string _name;
        public string Name
        {
            get { return Patient.Name ?? _name; }
            set
            {
                Patient.Name = value;
                SetProperty(ref _name, value);
            }
        }

        private string _patron;
        public string Patronymic
        {
            get { return Patient.Patronymic ?? _patron; }
            set
            {
                Patient.Patronymic = value;
                SetProperty(ref _patron, value);
            }
        }

        private string _sex;
        public string Sex
        {
            get { return Patient.Sex ?? _sex; }
            set
            {
                Patient.Sex = value;
                SetProperty(ref _sex, value);
            }
        }

        private DateTime _birth;
        public DateTime Birthday
        {
            get
            {
                if (Patient?.Birthday != null)
                    return Patient.Birthday;
                else return _birth;
            }
            set
            {
                Patient.Birthday = value;
                SetProperty(ref _birth, value);
            }
        }

        private string _phone;
        public string Phone
        {
            get { return Patient.Phone ?? _phone; }
            set
            {
                Patient.Phone = value;
                SetProperty(ref _phone, value);
            }
        }

        private string _adress;
        public string Adress
        {
            get { return Patient.Adress ?? _adress; }
            set
            {
                Patient.Adress = value;
                SetProperty(ref _adress, value);
            }
        }
        */
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
                var results = new List<ValidationResult>();
                var context = new ValidationContext(Patient);
                if (!Validator.TryValidateObject(Patient, context, results, true))
                {
                    string errorText = string.Empty;
                    foreach (var error in results)
                    {
                        errorText += error.ErrorMessage + "\n";
                    }
                    MessageBox.Show(errorText, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                App.dBContent.PersonalCards.Add(Patient);
                App.dBContent.SaveChanges();
            }
            else
                MessageBox.Show("Ошибка сохранения записи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            OnRequestClose(this, new EventArgs());
        }

        private void SaveEditedRecord()
        {
            if (Patient != null)
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(Patient);
                if (!Validator.TryValidateObject(Patient, context, results, true))
                {
                    string errorText = string.Empty;
                    foreach (var error in results)
                    {
                        errorText += error.ErrorMessage + "\n";
                    }
                    MessageBox.Show(errorText, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

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
            else
                MessageBox.Show("Ошибка сохранения записи.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            OnRequestClose(this, new EventArgs());
        }
        #endregion

        public ProfileViewModel(PersonalCard patientData, bool isEdit = false)
        {
            IsEdit = isEdit;
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
            } ?? new PersonalCard();

        }

    }
}
