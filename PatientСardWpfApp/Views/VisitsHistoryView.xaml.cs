using System.Windows;

namespace PatientСardWpfApp.Views
{
    /// <summary>
    /// Логика взаимодействия для PatientVisitsHistoryView.xaml
    /// </summary>
    public partial class VisitsHistoryView : Window
    {
        public VisitsHistoryView()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
