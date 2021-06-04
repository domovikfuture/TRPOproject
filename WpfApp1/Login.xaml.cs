using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text.Trim().ToUpper(); 
            string password1 = firstPassBox.Password.Trim();

            bool isGood = true;
            if (login.Length < 1)
            {
                isGood = false;
                loginBox.ToolTip = "Введите логин!";
                loginBox.Foreground = Brushes.Red;
            }
            else
            {
                loginBox.ToolTip = " ";
                loginBox.Foreground = Brushes.Black;
            }

            if (password1.Length < 1)
            {
                isGood = false;
                firstPassBox.ToolTip = "Введите пароль!";
                firstPassBox.Foreground = Brushes.Red;
            }
            else
            {
                firstPassBox.ToolTip = " ";
                firstPassBox.Foreground = Brushes.Black;
            }

            if (isGood == true)
            {
                DataTable table = SQLbase.Select($"select * from Customer where login = '{login}'");
              
                if (table.Rows.Count > 0)
                {
                    loginBox.ToolTip = " ";
                    loginBox.Foreground = Brushes.Black;
                    table = SQLbase.Select($"select * from Customer where login = '{login}' and pass = '{password1}'");
                    if(table.Rows.Count > 0)
                    {
                        MessageBox.Show("Сюда лут");
                    }
                    else
                    {
                        firstPassBox.ToolTip = "Неправильный пароль!";
                        firstPassBox.Foreground = Brushes.Red;
                    }
                }
                else
                {
                    loginBox.ToolTip = "Такого пользователя не существует!";
                    loginBox.Foreground = Brushes.Red;
                }
            }
        }
    }
}
