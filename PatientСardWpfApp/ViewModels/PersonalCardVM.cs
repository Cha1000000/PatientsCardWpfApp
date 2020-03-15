using System.ComponentModel.DataAnnotations;
using PatientСardWpfApp.Models;
using Prism.Mvvm;

namespace PatientСardWpfApp.ViewModels
{
    class PersonalCardVM : BindableBase
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

        public PersonalCard Card { get; set; }

        #region Properties
        public int Id { 
            get { return Card._id; }
            set { SetProperty(ref Card._id, value); } 
        }

        [Display(Name = "Имя")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина имени не менее 5 символов")]
        public string Name { 
            get { return Card._name; }
            set { SetProperty(ref Card._name, value); }
        }

        [Display(Name = "Фамилия")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина фамилии не менее 3 символов")]
        public string Surname {
            get { return Card._surname; }
            set { SetProperty(ref Card._surname, value); }
        }

        [Display(Name = "Отчество")]
        [StringLength(25)]
        [Required(ErrorMessage = "Длина отчества не менее 5 символов")]
        public string Patronymic {
            get { return Card._patronymic; }
            set { SetProperty(ref Card._patronymic, value); }
        }

        [Display(Name = "Пол")]
        public string Sex {
            get { return Card._sex; }
            set { SetProperty(ref Card._sex, value); }
        }
        
        [Display(Name = "Дата рождения")]
        [DataType(DataType.DateTime)]
        [StringLength(10)]
        public string Birthday {
            get { return Card._birthday; }
            set { SetProperty(ref Card._birthday, value); }
        }

        [Display(Name = "Адрес")]
        [StringLength(50)]
        [Required(ErrorMessage = "Длина адреса не менее 15 символов")]
        public string Adress {
            get { return Card._adress; }
            set { SetProperty(ref Card._adress, value); }
        }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(12)]
        [Required(ErrorMessage = "Длин номера не менее 10 символов")]
        public string Phone {
            set { SetProperty(ref Card._phone, value); }
        }
        #endregion


    }
}
