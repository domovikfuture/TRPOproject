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
            ShowList();
        }

        public Orders(string login="")
        {
            this.LOGIN = login;
            InitializeComponent();
            ShowList();
        }

        private void ShowList()
        {
            DataTable table = SQLbase.Select($"select login, good, count, price from Orders inner join Goods on Orders.good = Goods.name where login = N'{LOGIN}'");

            listGoods.ItemsSource = table.DefaultView;

            double sum = 0;

            if(table.Rows.Count == 0)
            {
                orderPrice.Content = $"Сумма заказа:";
                return;
            }

            for(int i = 0; i < table.Rows.Count; i++)
            {
                sum += (double)table.Rows[i][3] * (int)table.Rows[i][2];
            }

            orderPrice.Content = $"Сумма заказа: {sum}";
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

            if (x == -1 || s.Length == 0)
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
            SQLbase.Insert($"update Orders set count = {int.Parse(Count.Text)} where login = N'{LOGIN}' and good = N'{table.Rows[x][1]}'");

            ShowList();
        }

        private void makeSelect(object sender, SelectionChangedEventArgs e)
        {

            int i = listGoods.SelectedIndex;

            if(i == -1)
            {
                Count.Text = "";
                return;
            }

            DataRowView x = (DataRowView)listGoods.Items[i];
            //string s = "";
            //foreach (var item in x.Row.ItemArray)
            //{
            //    s += item.ToString() + "*";
            //}
            //MessageBox.Show(x.Row.ItemArray[0].ToString() + "\n\n" + s);// x.Row.Field<double>("price").ToString());

            Count.Text = x.Row.ItemArray[2].ToString();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            int x = listGoods.SelectedIndex;

            if (x == -1)
            {
                ButtonDelete.ToolTip = "Выберите элемент!";
                ButtonDelete.Foreground = Brushes.Red;
                return;
            }
            else
            {
                ButtonDelete.ToolTip = "";
                ButtonDelete.Foreground = Brushes.LightGreen;
            }

            DataTable table = SQLbase.Select($"select * from Orders where login = N'{LOGIN}'");

            DataRowView i = (DataRowView)listGoods.Items[x];
            SQLbase.Insert($"delete Orders where good = N'{i.Row.ItemArray[1].ToString()}'");
            
            ShowList();
        }

        private void End(object sender, RoutedEventArgs e)
        {

        }
    }
}
