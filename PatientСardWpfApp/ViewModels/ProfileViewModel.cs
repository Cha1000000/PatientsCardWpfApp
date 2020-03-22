using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace PatientСardWpfApp.ViewModels
{
    class ProfileViewModel : BindableBase
    {
        public event EventHandler OnRequestClose;
        private bool IsEdit { get; set; }

        IValidator Validator;
        IProfileAdder ProfileAdder;

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
            if (Validator.IsValid(Patient))
                ProfileAdder.SaveNewProfile(Patient);
            else return;

            OnRequestClose(this, new EventArgs());
        }

        private void SaveEditedRecord()
        {
            if (Validator.IsValid(Patient))
                ProfileAdder.UpdateRecord(Patient);
            else return;

            OnRequestClose(this, new EventArgs());
        }
        #endregion

        //-----------------------------------------------------------------------------
        public ProfileViewModel(IValidator valid, IProfileAdder profileAdder, PersonalCard patientData, bool isEdit = false)
        {
            Validator = valid;
            ProfileAdder = profileAdder;

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
