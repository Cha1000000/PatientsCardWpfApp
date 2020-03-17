using System.Windows;
using CommonServiceLocator;
using PatientСardWpfApp.Views;
using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.Reposetory;
using Prism.Unity;

namespace PatientСardWpfApp
{
    /// <summary>
    /// Autofac Bootstrapper 
    /// </summary>
    [System.Obsolete]
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            //return Container.Resolve<MainWindow>();
            return ServiceLocator.Current.GetInstance<MainWindow>();
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

            /*Container.RegisterInstance<CallbackLogger>(this.callbackLogger);*/
        }

    }
}
