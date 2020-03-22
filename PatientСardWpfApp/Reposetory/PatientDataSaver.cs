using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Models;
using System;
using System.Data.Entity;
using System.Windows;

namespace PatientСardWpfApp.Reposetory
{
    public class PatientDataSaver : IProfileAdder
    {
        /// <summary>
        /// Добавление новой учётной записи пациента в БД
        /// </summary>
        /// <param name="patientData">Объект с данными пациента</param>
        public void SaveNewProfile(PersonalCard patientData)
        {
            try
            {
                App.dBContent.PersonalCards.Add(patientData);
                App.dBContent.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorText = $"Ошибка сохранения записи.\n\nПодробнее: {ex.ToString()}";
                MessageBox.Show(errorText, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обновление изменённых данных пациента в БД
        /// </summary>
        /// <param name="patientData">Объект с данными пациента</param>
        public void UpdateRecord(PersonalCard patientData)
        {
            var dbRecord = App.dBContent.PersonalCards.Find(patientData.Id);
            if (dbRecord != null)
            {
                dbRecord.Name = patientData.Name;
                dbRecord.Surname = patientData.Surname;
                dbRecord.Patronymic = patientData.Patronymic;
                dbRecord.Sex = patientData.Sex;
                dbRecord.Birthday = patientData.Birthday;
                dbRecord.Phone = patientData.Phone;
                dbRecord.Adress = patientData.Adress;
                App.dBContent.Entry(dbRecord).State = EntityState.Modified;
                App.dBContent.SaveChanges();
            }
        }
    }
}
