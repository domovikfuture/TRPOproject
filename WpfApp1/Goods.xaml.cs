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
        Criterion crt;

        public Goods()
        {
            InitializeComponent();
            ShowList($"select * from Goods");
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

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    DataRowView x = (DataRowView)listGoods.Items[0];
        //    string s = "";
        //    foreach (var item in x.Row.ItemArray)
        //    {
        //        s += item.ToString()+"*";
        //    }
        //    MessageBox.Show(x.Row.ItemArray[0].ToString()+"\n\n"+s);// x.Row.Field<double>("price").ToString());
        //}

        private void AddGoods(object sender, RoutedEventArgs e)
        {
            int x = listGoods.SelectedIndex;


            if (x == -1)
            {
                ButtonAdd.ToolTip = "Выберите элемент!";
                ButtonAdd.Foreground = Brushes.Red;
                MessageBox.Show(x.ToString());
                return;
            }
            else
            {
                ButtonAdd.ToolTip = "";
                ButtonAdd.Foreground = Brushes.LightGreen;
            }
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

            ShowList($"select * from Goods");
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string price = SeatchPrice.Text;
            string name = SearchName.Text;

            if ((name.Trim().Length == 0 || name == null) && price.Trim().Length > 0)
            {
                int price_int = int.Parse(price);
                if (crt == Criterion.equal)
                {
                    ShowList($"select * from Goods where price = {price_int}");

                }
                if (crt == Criterion.more)
                {
                    ShowList($"select * from Goods where price >= {price_int}");

                }
                if (crt == Criterion.less)
                {
                    ShowList($"select * from Goods where price <= {price_int}");

                }
                return;
            }
            else if ((price.Trim().Length == 0 || price == null) && name.Trim().Length > 0)
            {
                if (crt == Criterion.equal)
                {
                    ShowList($"select * from Goods where name = '{name}'");

                }
                if (crt == Criterion.more)
                {
                    ShowList($"select * from Goods where name = '{name}'");

                }
                if (crt == Criterion.less)
                {
                    ShowList($"select * from Goods where name = '{name}'");

                }
                return;
            }
            else if (name.Trim().Length > 0 && price.Trim().Length > 0)
            {
                if (crt == Criterion.equal)
                {
                    ShowList($"select * from Goods where price = {price} and name = '{name}'");

                }
                if (crt == Criterion.more)
                {
                    ShowList($"select * from Goods where price >= {price} and name = '{name}'");

                }
                if (crt == Criterion.less)
                {
                    ShowList($"select * from Goods where price <= {price} and name = '{name}'");

                }
                return;
            }
            else
            {
                ShowList($"select * from Goods");
            }
        }
    }
}
