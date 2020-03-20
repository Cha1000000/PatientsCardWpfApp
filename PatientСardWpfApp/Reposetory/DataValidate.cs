using PatientСardWpfApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PatientСardWpfApp.Reposetory
{
    class DataValidate : IValidator
    {
        public bool IsValid(object o)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(o);
            if (!Validator.TryValidateObject(o, context, results, true))
            {
                string errorText = string.Empty;
                foreach (var error in results)
                {
                    errorText += error.ErrorMessage + "\n";
                }
                MessageBox.Show(errorText, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
