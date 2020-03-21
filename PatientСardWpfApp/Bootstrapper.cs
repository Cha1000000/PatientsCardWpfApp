using System.Windows;
using CommonServiceLocator;
using PatientСardWpfApp.Views;
using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Reposetory;
using Prism.Unity;

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

            /*Container.RegisterInstance<CallbackLogger>(this.callbackLogger);*/
        }

    }
}
