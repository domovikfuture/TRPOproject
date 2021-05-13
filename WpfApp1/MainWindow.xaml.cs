﻿using System;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = loginBox.Text.Trim().ToUpper();
            string []name = nameBox.Text.Trim().Split(" ");
            string password1 = firstPassBox.Password.Trim();
            string password2 = secondPassBox.Password.Trim();

            bool isGood = true; 
            //Проверка поля логина
            if(login.Length < 5)
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

            //Поле фио
            if (name.Length != 3)
            {
                isGood = false;
                nameBox.ToolTip = "Требуется полное написание ФИО!";
                nameBox.Foreground = Brushes.Red;
            }
            else
            {
                nameBox.ToolTip = " ";
                nameBox.Foreground = Brushes.Black;
            }

            //Проверка пароля
            if(password1.Length < 6)
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

            //Подтверждение пароля
            if(password1 != password2)
            {
                isGood = false;
                secondPassBox.ToolTip = "Пароли не совпадают";
                secondPassBox.Foreground = Brushes.Red;
            }
            else
            {
                secondPassBox.ToolTip = " ";
                secondPassBox.Foreground = Brushes.Black;
            }

            if(isGood == true)
            {
                MessageBox.Show("Ура ты не дебил!");
            }
        }
    }
}
