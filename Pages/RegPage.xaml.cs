using BCrypt.Net;
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
using TourCompany.Models;

namespace TourCompany.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void BtnBAck_Click(object sender, RoutedEventArgs e)
        {
            NavigateClass.navigate.GoBack();
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pass = PsbBox.Password.ToString();
                string log = TxbLog.Text;
                string copyPass = PsbCopyBox.Password.ToString();
                if (pass == copyPass)
                {
                    if (pass != "" || log != "")
                    {
                        if (pass.Length >= 6)
                        {
                            string hashPass = BCrypt.Net.BCrypt.HashPassword(pass);
                            User newUser = new User()
                            {
                                Login = log,
                                Password = hashPass,
                                StatusId = 1,
                                RoleId = 1,
                            };
                            ConnectClass.connect.Users.Add(newUser);
                            ConnectClass.connect.SaveChanges();
                            MessageBox.Show("Хорошо");
                        }
                        else
                        {
                            MessageBox.Show("Ваш пароль слишком короткий");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы не ввели данные");
                    }
                }
                else
                {
                    MessageBox.Show("Плохо");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Очень плохо");
            }
        }
    }
}
