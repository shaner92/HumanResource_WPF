using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace HumanResource_WPF
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        private byte[] bytePic = new byte[0];
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void btnAddEmployee(object sender, RoutedEventArgs e)
        {
            
            var context = new HrDBContext();

            var employee = new Employee()

            {
                FirstName = "test",
                LastName = "test",
                HireDate = DateTime.Now,
                Position = "test",
                Email = "test",
                PayRate = 2.25,
                Picture = bytePic
            };
            context.Employees.Add(employee);
            context.SaveChanges();
            
        }

        private void btnUploadImg(object sender, RoutedEventArgs e)
        {
           OpenFileDialog dlg = new OpenFileDialog();
            //Filter for images only
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                var img = new HelperClasses.ImageConvertor();
                bytePic = img.imageToByteArray(filename);
            }

        }
    }
}
