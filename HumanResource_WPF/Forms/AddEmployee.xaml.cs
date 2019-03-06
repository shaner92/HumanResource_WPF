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
            //var fd  = new OpenFileDialog();
            //fd.Title = "Open File Dialog"
            //fd.InitialDirectory = "C:\Users\shaner\Desktop\PDDs"
            var img = new HelperClasses.ImageConvertor();
            bytePic = img.imageToByteArray(@"C:\Users\shaner\OneDrive - Sciemetric Instruments\Documentation\Brazil Visa\visa_photo.jpeg");
        }
    }
}
