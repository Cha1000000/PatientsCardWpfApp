﻿using PatientСardWpfApp.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace PatientСardWpfApp.Views
{
    public partial class MainWindow : Window
    {                
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowVM();            
        }

        void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch { }
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
