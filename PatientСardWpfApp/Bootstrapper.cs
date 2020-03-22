using CommonServiceLocator;
using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Reposetory;
using PatientСardWpfApp.Views;
using Prism.Unity;
using System.Windows;

namespace PatientСardWpfApp
{
    [System.Obsolete]
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //return Container.TryResolve<Shell>();
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        /// <summary>Initializes the shell.</summary>
        protected override void InitializeShell()
        {
            //base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Регистрация интерфейсов и классов их реализации
            RegisterTypeIfMissing(typeof(IVisitsAdder), typeof(VisitAdd), true);
            RegisterTypeIfMissing(typeof(IVisitRemover), typeof(VisitRemove), true);
            RegisterTypeIfMissing(typeof(IValidator), typeof(DataValidate), true);
            RegisterTypeIfMissing(typeof(IDBLoader), typeof(DBDownload), true);
            RegisterTypeIfMissing(typeof(IPatientRemover), typeof(PatientDataRemove), true);
            RegisterTypeIfMissing(typeof(IProfileAdder), typeof(PatientDataSaver), true);

            /*Container.RegisterInstance<CallbackLogger>(this.callbackLogger);*/
        }

    }
}
