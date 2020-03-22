using Prism.Mvvm;
using System;
using System.ComponentModel.DataAnnotations;

namespace PatientСardWpfApp.Models
{
    public class Visit : BindableBase
    {
        private int id;
        private DateTime _date = DateTime.Now.Date;
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

        [DataType(DataType.Date)]
        public DateTime Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        [StringLength(15, MinimumLength = 5)]
        [Required(ErrorMessage = "Длина строки должна быть не менее 4 символов")]
        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }

        [StringLength(100)]
        public string Diagnosis
        {
            get { return _diagnosis; }
            set { SetProperty(ref _diagnosis, value); }
        }

        #endregion

        public Visit() { }

        public Visit(int Pid, DateTime dateTime, string vType, string diagnosis)
        {
            pid = Pid;
            _date = dateTime;
            _type = vType;
            _diagnosis = diagnosis;
        }
    }
}
