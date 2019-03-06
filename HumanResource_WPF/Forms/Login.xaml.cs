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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var password = PasswordCrypt.SimpleEncrypt(txtPW.Password);
            using (var context = new HrDBContext()) { 
                var username = txtID.Text;
                try
                {
                    var user = context.Users.Where(un => un.UserName == username).Where(pw => pw.Password == password).First();
                    MainWindow form = new MainWindow();
                    form.Tag = this;
                    form.Show();
                    Hide();
                }
                catch
                {
                    MessageBox.Show("Could not validate user");
                }
            }
        }

        private void btnSingUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp form = new SignUp();
            form.Tag = this;
            form.Show();
            Hide();
        }
    }
}
