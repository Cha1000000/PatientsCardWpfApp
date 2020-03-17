using System.Windows;
using System.Windows.Input;

namespace PatientСardWpfApp
{
    public partial class MyTheme
    {
        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var W = sender as Window;
                if (sender is Window)
                    W.DragMove();
            }
            catch { }
        }

        public void btExit_Click(object sender, RoutedEventArgs e)
        {
            var W = sender as System.Windows.Controls.Button;
            Application.Current.MainWindow.Close();
        }

        private void btMin_Click(object sender, RoutedEventArgs e)
        {
            var W = sender as System.Windows.Controls.Button;
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            var W = sender as System.Windows.Controls.Button;
            Application.Current.MainWindow.WindowState = (Application.Current.MainWindow.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }
    }    
}
