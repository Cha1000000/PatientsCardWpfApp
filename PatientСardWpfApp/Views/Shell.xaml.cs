using PatientСardWpfApp.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace PatientСardWpfApp.Views
{
    public partial class Shell : Window
    {                
        public Shell()
        {
            InitializeComponent();
            DataContext = new ShellViewModel();            
        }

        private void DataGridRow_Unselected(object sender, RoutedEventArgs e)
        {
            //dgPatients.UnselectAll();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
    }
}
