using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HumanResource_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Employee> _employee = new ObservableCollection<Employee>();
        public MainWindow()
        {
            InitializeComponent();

            using (var context = new HrDBContext())
            {
                foreach (var employee in context.Employees)
                {
                    Employee emp = new Employee() { EmployeeID = employee.EmployeeID, PayRate = employee.PayRate };
                    _employee.Add(emp);
                }
            }
            roomSeries.ItemsSource = _employee;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnEmployeesClick(object sender, RoutedEventArgs e)
        {
            EmployeeList form = new EmployeeList();
            form.Tag = this;
            form.Show();
            Hide();
        }
    }
}
