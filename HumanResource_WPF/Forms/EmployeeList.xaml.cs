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

namespace HumanResource_WPF
{
    /// <summary>
    /// Interaction logic for EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Window
    {
      
        public EmployeeList()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow form = new MainWindow();
            form.Tag = this;
            form.Show();
        }


        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee form = new AddEmployee();
            form.Tag = this;
            form.Show();
            Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var context = new HrDBContext())
            {
                var list = context.Employees.ToList();
                DGVEmployees.ItemsSource = list;
            }
               
        }

        
    }
}
