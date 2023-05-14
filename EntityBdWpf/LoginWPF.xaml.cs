using EntityBdWpf.Service;
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

namespace EntityBdWpf
{
    /// <summary>
    /// Логика взаимодействия для LoginWPF.xaml
    /// </summary>
    public partial class LoginWPF : Window
    {
        public LoginWPF()
        {
            InitializeComponent();
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            UserAuthentificationDBService uads = new UserAuthentificationDBService();
            if(uads.ValidateUser(LoginValidate.Text, PasswordValidate.Text))
            {
                this.Close();
                MessageBox.Show("Вход выполнен");
            }
            else
            {
                MessageBox.Show("Не вернный логин или пароль");
            }
        }
    }
}
