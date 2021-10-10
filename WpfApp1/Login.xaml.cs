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
            string number = numberBox.Text;

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

            if (number.Length != 12)
            {
                isGood = false;
                numberBox.ToolTip = "Введите номер!";
                numberBox.Foreground = Brushes.Red;
            }
            else
            {
                numberBox.ToolTip = " ";
                numberBox.Foreground = Brushes.Black;
            }

            if (isGood == true)
            {
                if(login == "ADMIN" && number == "Admin")
                {
                    ListOrders s = new ListOrders();
                    s.Show();
                    this.Close();
                    return;
                }

                DataTable table = SQLbase.Select($"select * from Клиенты where id_клиента = '{login}'");
              
                if (table.Rows.Count > 0)
                {
                    loginBox.ToolTip = " ";
                    loginBox.Foreground = Brushes.Black;
                    table = SQLbase.Select($"select * from Клиенты where id_клиента = '{login}' and Телефон = '{number}'");
                    if(table.Rows.Count > 0)
                    {
                        Goods s = new Goods(login);
                        this.Close();

                        s.Show();
                    }
                    else
                    {
                        numberBox.ToolTip = "Неправильный пароль!";
                        numberBox.Foreground = Brushes.Red;
                    }
                }
                else
                {
                    loginBox.ToolTip = "Такого пользователя не существует!";
                    loginBox.Foreground = Brushes.Red;
                }
            }
        }

        private void GoToReg(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();

            m.Show();
        }
    }
}
