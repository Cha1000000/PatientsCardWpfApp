using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Models;
using PatientСardWpfApp.Reposetory;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Input;

namespace PatientСardWpfApp.ViewModels
{
    /// <summary>
    /// Модель логики Редактора записей посещений.
    /// </summary>
    class VisitEditorVM : BindableBase
    {
        public event EventHandler OnRequestClose;
        private bool IsEdit { get; set; }

        private Visit _visit;

        private IValidator Validator = new DataValidate();
        private IVisitsAdder Adder { get; set; } = new VisitAdd();

        #region Public Properties

        public Visit curVisit
        {
            get { return _visit; }
            set { SetProperty(ref _visit, value); }
        }

        public bool isOK { get; set; } = false;
        #endregion

        #region Сохранить запись
        private DelegateCommand saveRecCommand;

        public ICommand SaveRecCommand
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
            if (Validator.IsValid(curVisit))
            {
                Adder.NewVisitRecord(curVisit);
                isOK = true;
            }
            else return;
            OnRequestClose(this, new EventArgs());
        }

        private void SaveEditedRecord()
        {
            if (Validator.IsValid(curVisit))
                Adder.UpdateRecord(curVisit);
            else return;
            OnRequestClose(this, new EventArgs());
        }

        #endregion

        //-----------------------------------------------------------------------------
        public VisitEditorVM(bool isEdit = false)
        {
            IsEdit = isEdit;
        }

    }
}
