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
    /// Логика взаимодействия для Goods.xaml
    /// </summary>
    public partial class Goods : Window
    {
        public Goods()
        {
            InitializeComponent();
            ShowList();
        }

        private void ShowList()
        {
            DataTable talbe = SQLbase.Select($"select * from Goods");
            listGoods.ItemsSource = talbe.DefaultView;
        }
    }
}
