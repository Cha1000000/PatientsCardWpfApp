using Prism.Mvvm;
using System;

namespace PatientСardWpfApp.Models
{
    public class Visit : BindableBase
    {
        private int id;
        private DateTime _date;
        private string _type;
        private string _diagnosis;
        private int pid;

        #region Properties
        public int Id
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        public int PatientId
        {
            get { return pid; }
            set { SetProperty(ref pid, value); }
        }

        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

         public string Diagnosis
        {
            get { return _diagnosis; }
            set { SetProperty(ref _diagnosis, value); }
        }
        #endregion

        public Visit() {  }

        public Visit(int Pid, DateTime dateTime, string vType, string diagnosis)
        {
            pid = Pid;
            _date = dateTime;
            _type = vType;
            _diagnosis = diagnosis;
        }
    }
}
