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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        public Orders(string login="")
        {
            InitializeComponent();
        }

        //private void Edit(object sender, RoutedEventArgs e)
        //{
        //    string s = Count.Text;

        //    foreach (Char x in s)
        //    {
        //        if (!char.IsDigit(x))
        //        {
        //            Count.ToolTip = "Требуется числовое значение!";
        //            Count.Foreground = Brushes.Red;
        //            return;
        //        }
        //        else
        //        {
        //            Count.ToolTip = "";
        //            Count.Foreground = Brushes.Black;
        //        }
        //    }


        //}
    }
}
