using System.Windows;
using Autofac;
using Prism.Autofac;
using PatientСardWpfApp.Views;
using Prism.Unity;
using Unity;

namespace PatientСardWpfApp
{
    /// <summary>
    /// Autofac Bootstrapper 
    /// </summary>
    [System.Obsolete]
    public class Bootstrapper : UnityBootstrapper //AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        /// <summary>Initializes the shell.</summary>
        protected override void InitializeShell()
        {
            //base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Creates the <see cref="T:Autofac.ContainerBuilder" /> that will be used to create the default container.
        /// </summary>
        /// <returns>A new instance of <see cref="T:Autofac.ContainerBuilder" />.</returns>
        /*protected override ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            // регистрация зависимостей в контейнере
            // должны быть здесь...

            return builder;
        }*/
    }
}
