using System.Windows;

namespace PatientСardWpfApp.Views
{
    /// <summary>
    /// Логика взаимодействия для VisitEditView.xaml
    /// </summary>
    public partial class VisitEditView : Window
    {
        public VisitEditView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Закрыть окно без сохранения данных?",
                                "Подтверждение действия",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
                Close();
        }
    }
}
