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
    /// Логика взаимодействия для ListOrders.xaml
    /// </summary>
    public partial class ListOrders : Window
    {
        private string LOGIN;

        public ListOrders()
        {
            LOGIN = "Admin";
            InitializeComponent();
            ShowList();
        }

        public ListOrders(string login)
        {
            this.LOGIN = login;
            InitializeComponent();
            ShowList();
        }

        private void ShowList()
        {
            DataTable table = SQLbase.Select($"select * from Orders");
            listGoods.ItemsSource = table.DefaultView;
        }
    }
}
