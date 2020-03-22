using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace PatientСardWpfApp.Reposetory
{
    class PatientDataRemove : IPatientRemover
    {
        public void DeleteProfile(PersonalCard record)
        {
            // Сперва удаляем все, связанные с пациентом, записи посещений:
            try
            {
                if (App.dBContent.Visits == null)
                    App.dBContent.Visits.Load();
                var temp = App.dBContent.Visits.ToList();
                if (temp != null)
                {
                    if (temp.Any(r => r.PatientId == record.Id))
                    {
                        foreach (var item in temp)
                        {
                            if (item.PatientId.Equals(record.Id))
                            {
                                var selecteditem = from t in App.dBContent.Visits
                                                   where t.Id == item.Id
                                                   select t;
                                App.dBContent.Visits.Remove(selecteditem.FirstOrDefault());
                            }
                        }
                        App.dBContent.SaveChanges();
                    }
                }
            }
            catch(Exception ex)
            {
                string error = "Возникла ошибка во время удаления записей посещений пациента." +
                               $"\n\nИнформация об ошибке: {ex.ToString()}";
                MessageBox.Show(error, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);     
            }

            // Теперь можно удалять запись самого пациента:
            {
                var temp = App.dBContent.PersonalCards.ToList();
                var selecteditem = from t in App.dBContent.PersonalCards
                                   where t.Id == record.Id
                                   select t;
                App.dBContent.PersonalCards.Remove(selecteditem.FirstOrDefault());
                App.dBContent.SaveChanges();
            }
        }

    }
}
