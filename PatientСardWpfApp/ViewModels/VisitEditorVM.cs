using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Models;
using PatientСardWpfApp.Reposetory;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PatientСardWpfApp.ViewModels
{
    class VisitEditorVM : BindableBase
    {
        private Visit _visit;
        private PersonalCard _pacientCard;

        private DateTime _creationDate = DateTime.Now;
        private string _type = "Первичный";
        private string _diag;
        
        private int curWin = App.Current.Windows.Count - 2;

        #region Public Properties
        public Visit Visit
        {
            get { return _visit; }
            set { SetProperty(ref _visit, value); }
        }
        
        public DateTime Date
        {
            get { return _creationDate; }
            set { SetProperty(ref _creationDate, value); }
        }

        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        public string Diagnosis
        {
            get { return _diag; }
            set { SetProperty(ref _diag, value); }
        }

        IVisitsAdder Adder { get; set; } = new VisitAdd();

        #endregion

        #region Сохранить запись
        private DelegateCommand saveRecCommand;

        public ICommand SaveRecCommand
        {
            get
            {
                if (saveRecCommand == null)
                {
                    saveRecCommand = new DelegateCommand(SaveRecord);
                }
                return saveRecCommand;
            }
        }

        private void SaveRecord()
        {
            if (_pacientCard != null)
            Visit = Adder.NewVisitRecord(_pacientCard.Id, Date, Type, Diagnosis);
            // Здесь должно быть обновление в БД
            System.Windows.MessageBox.Show("Данные успешно сохранены.", "Сообщение");
            App.Current.Windows[curWin].Close();
        }
        #endregion

        //-----------------------------------------------------------------------------
        public VisitEditorVM(PersonalCard PatientCard)
        {
            if (PatientCard != null)
                _pacientCard = PatientCard;
            
        }
        
    }
}
