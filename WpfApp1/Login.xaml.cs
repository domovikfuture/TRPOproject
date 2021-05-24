using System;
using System.Collections.Generic;
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
            if (login.Length < 5)
            {
                isGood = false;
                loginBox.ToolTip = "Длина логина должна быть от 5 букв!";
                loginBox.Foreground = Brushes.Red;
            }
            else
            {
                loginBox.ToolTip = " ";
                loginBox.Foreground = Brushes.Black;
            }

            if (password1.Length < 6)
            {
                isGood = false;
                firstPassBox.ToolTip = "Длина пароля должна быть от 6 символов!";
                firstPassBox.Foreground = Brushes.Red;
            }
            else
            {
                firstPassBox.ToolTip = " ";
                firstPassBox.Foreground = Brushes.Black;
            }

            if (isGood == true)
            {
                MessageBox.Show("Ура ты не дебил!");
            }
        }
    }
}
