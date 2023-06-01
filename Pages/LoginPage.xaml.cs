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
using TourCompany.Classes;

namespace TourCompany.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pass = PsbBox.Password.ToString();
                var conn = ConnectClass.connect.Users.FirstOrDefault(x => x.Login == TxbLog.Text);
                bool verifPass = BCrypt.Net.BCrypt.Verify(pass,conn.Password);
                if(verifPass == true & conn != null)
                {
                    MessageBox.Show("Авторизация пройдена");
                }
                else
                {
                    MessageBox.Show("Неверно введены данные");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка сервера");
            }

        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.navigate.Navigate(new RegPage());
        }
    }
}
