﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
