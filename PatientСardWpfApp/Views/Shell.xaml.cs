using PatientСardWpfApp.Interfaces;
using PatientСardWpfApp.ViewModels;
using System.Windows;

namespace PatientСardWpfApp.Views
{
    public partial class Shell : Window
    {
        public Shell(IDBLoader loader, IPatientRemover remover, IValidator valid, IProfileAdder profileAdder, IVisitRemover vRemover)
        {
            InitializeComponent();
            DataContext = new ShellViewModel(loader, remover, valid, profileAdder, vRemover);
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
