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

            
            if(x == -1)
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

            if (s == "Меньше")
            {
                crt = Criterion.less;
            }throw new Exception("Незаконченный функционал");
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            SeatchPrice.Text = "";
            SearchName.Text = "";
        }
    }
}
