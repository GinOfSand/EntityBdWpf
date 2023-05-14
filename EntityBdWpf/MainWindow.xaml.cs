using EntityBdWpf.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityBdWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        
        private void Close_click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {

            
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Database.Connection.Close();
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            HideCloseBTN.Visibility= Visibility.Visible;
            HideEnterBTN.Visibility= Visibility.Visible;
            RegLoginTB.Visibility= Visibility.Visible;
            RegPassTB.Visibility= Visibility.Visible;
            RegisterBTN.Visibility= Visibility.Hidden;
            LoginBTN.Visibility= Visibility.Hidden;
            ClosingBTN.Visibility= Visibility.Hidden;   
        }

        private void HideEnterBTN_Click(object sender, RoutedEventArgs e)
        {
           
           UserAuthentificationDBService db = new UserAuthentificationDBService();
           if(db.RegisterUser(RegLoginTB.Text, RegPassTB.Text))
            {
                HideCloseBTN.Visibility = Visibility.Hidden;
                HideEnterBTN.Visibility = Visibility.Hidden;
                RegLoginTB.Visibility = Visibility.Hidden;
                RegPassTB.Visibility = Visibility.Hidden;
                RegisterBTN.Visibility = Visibility.Visible;
                LoginBTN.Visibility = Visibility.Visible;
                ClosingBTN.Visibility = Visibility.Visible;
            }

            
        }

        private void HideCloseBTN_Click(object sender, RoutedEventArgs e)
        {
            HideCloseBTN.Visibility = Visibility.Hidden;
            HideEnterBTN.Visibility = Visibility.Hidden;
            RegLoginTB.Visibility = Visibility.Hidden;
            RegPassTB.Visibility = Visibility.Hidden;
            RegisterBTN.Visibility = Visibility.Visible;
            LoginBTN.Visibility = Visibility.Visible;
            ClosingBTN.Visibility = Visibility.Visible;
        }
    }

}
