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
using System.Linq;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Goods.xaml
    /// </summary>
    public partial class Goods : Window
    {
        Criterion crt;
        string LOGIN;

        public Goods(string _login = "")
        {
            InitializeComponent();

            this.LOGIN = _login;
            ShowList($"select * from Товары");
        }

        public Goods()
        {
            LOGIN = "Admin";
            InitializeComponent();
            ShowList($"select * from Товары");
        }

        private enum Criterion
        {
            more,
            less,
            equal
        }

        private void ShowList(string str)
        {
            DataTable talbe = SQLbase.Select(str);

            listGoods.ItemsSource = talbe.DefaultView;
        }


        private void AddGoods(object sender, RoutedEventArgs e)
        {
            int x = listGoods.SelectedIndex;

            DataTable table = SQLbase.Select($"select * from Товары");
            

            if (x == -1)
            {
                ButtonAdd.ToolTip = "Выберите элемент!";
                ButtonAdd.Foreground = Brushes.Red;
                return;
            }
            else
            {
                ButtonAdd.ToolTip = "";
                ButtonAdd.Foreground = Brushes.LightGreen;
            }

            SQLbase.Insert($"insert into Заказы( id_товара, id_клиента, Дата_размещения) values ( {table.Rows[x][0]}, '{LOGIN}', GETDATE())");

            MessageBox.Show("Товар добавлен!");

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            string s = pressed.Content.ToString();

            if (s == "Дешевле")
            {
                crt = Criterion.less;
                return;
            }
            if (s == "Дороже")
            {
                crt = Criterion.more;
                return;
            }
            if (s == "Ровно")
            {
                crt = Criterion.equal;
                return;
            }
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            SeatchPrice.Text = "";
            SearchName.Text = "";

            ShowList($"select * from Товары");
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string price = SeatchPrice.Text;
            string name = SearchName.Text;

            foreach(Char x in price)
            {
                if (!char.IsDigit(x))
                {
                    SeatchPrice.ToolTip = "Требуется числовое значение!";
                    SeatchPrice.Foreground = Brushes.Red;
                    return;
                }
                else
                {
                    SeatchPrice.ToolTip = "";
                    SeatchPrice.Foreground = Brushes.Black;
                }
            }

            if ((name.Trim().Length == 0 || name == null) && price.Trim().Length > 0)
            {
                int price_int = int.Parse(price);
                if (crt == Criterion.equal)
                {
                    ShowList($"select * from Товары where Стоимость = {price_int}");

                }
                if (crt == Criterion.more)
                {
                    ShowList($"select * from Товары where Стоимость >= {price_int}");

                }
                if (crt == Criterion.less)
                {
                    ShowList($"select * from Товары where Стоимость <= {price_int}");

                }
                return;
            }
            else if ((price.Trim().Length == 0 || price == null) && name.Trim().Length > 0)
            {
                if (crt == Criterion.equal)
                {
                    ShowList($"select * from Товары where [Название_товара] like '{name}%'");

                }
                if (crt == Criterion.more)
                {
                    ShowList($"select * from Товары where [Название_товара] like '{name}%'");

                }
                if (crt == Criterion.less)
                {
                    ShowList($"select * from Товары where [Название_товара] like '{name}%'");

                }
                return;
            }
            else if (name.Trim().Length > 0 && price.Trim().Length > 0)
            {
                if (crt == Criterion.equal)
                {
                    ShowList($"select * from Товары where price = {price} and Название_товара = '{name}'");

                }
                if (crt == Criterion.more)
                {
                    ShowList($"select * from Товары where price >= {price} and Название_товара = '{name}'");

                }
                if (crt == Criterion.less)
                {
                    ShowList($"select * from Товары where price <= {price} and Название_товара = '{name}'");

                }
                return;
            }
            else
            {
                ShowList($"select * from Товары");
            }
        }

        private void GoToOrders(object sender, RoutedEventArgs e)
        {
            Orders o = new Orders(LOGIN);
            this.Close();
            o.Show();
        }
    }
}
