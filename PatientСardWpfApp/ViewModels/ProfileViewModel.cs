using PatientСardWpfApp.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientСardWpfApp.ViewModels
{
    class ProfileViewModel : BindableBase
    {
        #region Public Properties
        private PersonalCard _patient;
        public PersonalCard Patient
        {
            get { return _patient; }
            set { SetProperty(ref _patient, value); }
        }


        private string _sur;
        public string Surname
        {
            get { return Patient.Surname ?? _sur; }
            set {
                  Patient.Surname = value;
                  SetProperty(ref _sur, value); }
        }
        
        private string _name;
        public string Name
        {
            get { return Patient.Name ?? _name; }
            set {
                  Patient.Name = value;
                  SetProperty(ref _name, value); }
        }
        
        private string _patron;
        public string Patronymic
        {
            get { return Patient.Patronymic ?? _patron; }
            set {
                  Patient.Patronymic = value;
                  SetProperty(ref _patron, value); }
        }
        
        private string _sex;
        public string Sex
        {
            get { return Patient.Sex ?? _sex; }
            set {
                  Patient.Sex = value;
                  SetProperty(ref _sex, value); }
        }

        private DateTime _birth;
        public DateTime Birthday
        {
            get { if (Patient?.Birthday != null)
                    return Patient.Birthday;
                else return _birth;
            }
            set {
                  Patient.Birthday = value;
                  SetProperty(ref _birth, value); }
        }

        private string _phone;
        public string Phone
        {
            get { return Patient.Phone ?? _phone; }
            set {
                  Patient.Phone = value;
                  SetProperty(ref _phone, value); }
        }

        private string _adress;
        public string Adress
        {
            get { return Patient.Adress ?? _adress; }
            set {
                  Patient.Adress = value;
                  SetProperty(ref _adress, value); }
        }

        #endregion

        public ProfileViewModel (PersonalCard patientData)
        {
            Patient = patientData ?? new PersonalCard();

        }

    }
}
