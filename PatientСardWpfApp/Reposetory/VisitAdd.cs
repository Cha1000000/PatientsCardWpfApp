using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Models;
using System;
using System.Data.Entity;
using System.Windows;

namespace PatientСardWpfApp.Reposetory
{
    public class VisitAdd : IVisitsAdder
    {
        /// <summary>
        /// Добавление новой записи о посещении в БД
        /// </summary>
        /// <param name="visitData">Объект с данными записей посещения</param>
        public void NewVisitRecord(Visit visitData)
        {
            try
            {
                App.dBContent.Visits.Add(visitData);
                App.dBContent.SaveChanges();
            }
            catch (Exception ex)
            {
                string errorText = $"Ошибка сохранения записи.\nПодробнее: {ex.ToString()}";
                MessageBox.Show(errorText, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Обновление изменённой записи в БД
        /// </summary>
        /// <param name="visitData">Объект с данными записей посещения</param>
        public void UpdateRecord(Visit visitData)
        {
            try
            {
                var dbRecord = App.dBContent.Visits.Find(visitData.Id);
                if (dbRecord != null)
                {
                    dbRecord.Date = visitData.Date;
                    dbRecord.Type = visitData.Type;
                    dbRecord.Diagnosis = visitData.Diagnosis;

                    App.dBContent.Entry(dbRecord).State = EntityState.Modified;
                    App.dBContent.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string errorText = $"Ошибка сохранения записи.\nПодробнее: {ex.ToString()}";
                MessageBox.Show(errorText, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
