using System;
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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            closeFrm();
        }
        private void closeFrm()
        {
            var logInForm = (Login)Tag;
            logInForm.Show();
            Close();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            var context = new HrDBContext();
            var user = new User()
            {
                FirstName = txtFN.Text,
                LastName = txtLN.Text,
                Position = txtPosition.Text,
                CreateDate = DateTime.Now,
                Email = txtEmail.Text,
                Password = PasswordCrypt.SimpleEncrypt(txtPW.Text)
            };
            context.Users.Add(user);
            context.SaveChanges();
            closeFrm();
        }
    }
}
