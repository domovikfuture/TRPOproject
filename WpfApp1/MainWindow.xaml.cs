using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
                InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text.Trim().ToUpper();
            string []name = nameBox.Text.Trim().Split(" ");
            string adr = adress.Text;
            string num = number.Text;

            bool isGood = true;
            //Проверка поля логина
            if (login.Length < 3 && login.Length > 20)
            {
                isGood = false;
                loginBox.ToolTip = "Длина логина должна быть от 3 до 20 букв!";
                loginBox.Foreground = Brushes.Red;
            }
            else
            {
                bool stop = false;

                foreach (char x in login)
                {
                    Console.WriteLine("yes");
                    if (Char.IsDigit(x))
                    {
                        stop = true;
                        break;
                    }

                    if (Convert.ToInt16(x) < 0 || Convert.ToInt16(x) > 128)
                    {
                        stop = true;
                        break;
                    }
                }

                if (stop)
                {
                    isGood = false;
                    loginBox.ToolTip = "Недопустимый ввод символов!";
                    loginBox.Foreground = Brushes.Red;
                }
                else
                {
                    DataTable table = SQLbase.Select($"select * from Клиенты where id_клиента = '{login}'");
                    if (table.Rows.Count > 0)
                    {
                        isGood = false;
                        loginBox.ToolTip = "Такой пользователь уже существует!";
                        loginBox.Foreground = Brushes.Red;
                    }
                    else
                    {
                        loginBox.ToolTip = " ";
                        loginBox.Foreground = Brushes.Black;
                    }
                }
            }

            //Поле фио
            if (!(name.Length == 2 || name.Length == 3))
            {
                isGood = false;
                nameBox.ToolTip = "Требуется полное написание ФИО!";
                nameBox.Foreground = Brushes.Red;
            }
            else
            {
                nameBox.ToolTip = "";
                nameBox.Foreground = Brushes.Black;
            }

            //Проверка пароля
            if(adr == "")
            {
                isGood = false;
                adress.ToolTip = "Пустое поле!";
                adress.Foreground = Brushes.Red;
            }
            else
            {
                adress.ToolTip = "";
                adress.Foreground = Brushes.Black;
            }
            
            //Подтверждение пароля
            if(num.Length != 12)
            {
                isGood = false;
                number.ToolTip = "Неверная длина";
                number.Foreground = Brushes.Red;
            }
            else
            {
                number.ToolTip = "";
                number.Foreground = Brushes.Black;
            }

            if(isGood == true)
            {
                loginBox.Text = "";
                nameBox.Text = "";
                adress.Text = "";
                number.Text = "";
                SQLbase.Insert($"insert into Клиенты(id_клиента, ФИО_клиента, Адрес, Телефон) values ('{login}', '{name[0]} {name[1]} {name[2]}', '{adr}', '{num}')");
                Login log = new Login();

                this.Close();
                log.Show();
            }
        }

        private void ButtonLoginGo(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            this.Close();

            log.Show();
        }
    }
}
