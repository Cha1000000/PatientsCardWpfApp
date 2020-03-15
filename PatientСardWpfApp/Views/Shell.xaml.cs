using PatientСardWpfApp.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace PatientСardWpfApp.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
            DataContext = new PersonalCardVM();
        }

        void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btMin_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        
        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = (WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }
    }
}
