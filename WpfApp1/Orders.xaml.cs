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
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        private string LOGIN;

        public Orders()
        {
            LOGIN = "Admin";
            InitializeComponent(); 
            ShowList($"select login, good, count, price from Orders inner join Goods on Orders.good = Goods.name where login = N'{LOGIN}'");
        }

        public Orders(string login="")
        {
            this.LOGIN = login;
            InitializeComponent();
            ShowList($"select login, good, count, price from Orders inner join Goods on Orders.good = Goods.name where login = N'{LOGIN}'");
        }

        private void ShowList(string str)
        {
            DataTable talbe = SQLbase.Select(str);

            listGoods.ItemsSource = talbe.DefaultView;
        }

        private void GoToGoods(object sender, RoutedEventArgs e)
        {
            Goods o = new Goods(LOGIN);
            this.Close();
            o.Show();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            string s = Count.Text;

            foreach (Char u in s)
            {
                if (!char.IsDigit(u))
                {
                    Count.ToolTip = "Требуется числовое значение!";
                    Count.Foreground = Brushes.Red;
                    return;
                }
                else
                {
                    Count.ToolTip = "";
                    Count.Foreground = Brushes.Black;
                }
            }

            int x = listGoods.SelectedIndex;

            if (x == -1)
            {
                ButtonEdit.ToolTip = "Выберите элемент!";
                ButtonEdit.Foreground = Brushes.Red;
                return;
            }
            else
            {
                ButtonEdit.ToolTip = "";
                ButtonEdit.Foreground = Brushes.LightGreen;
            }

            DataTable table = SQLbase.Select($"select * from Orders where login = N'{LOGIN}'");
            SQLbase.Insert($"update Orders set count = {(int)table.Rows[0][2] + 1} where login = N'{LOGIN}' and good = N'{table.Rows[x][0]}';");

            Count.Text = ((int)table.Rows[0][2] + 1).ToString();
        }

        private void makeSelect(object sender, SelectionChangedEventArgs e)
        {

            DataRowView x = (DataRowView)listGoods.Items[0];
            string s = "";
            foreach (var item in x.Row.ItemArray)
            {
                s += item.ToString() + "*";
            }
            MessageBox.Show(x.Row.ItemArray[0].ToString() + "\n\n" + s);// x.Row.Field<double>("price").ToString());

            Count.Text = x.Row.ItemArray[2].ToString();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {

        }

        private void End(object sender, RoutedEventArgs e)
        {

        }
    }
}
