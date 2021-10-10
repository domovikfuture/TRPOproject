using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : System.Windows.Window
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
            System.Data.DataTable table = SQLbase.Select($"SELECT Заказы.id_товара, Название_товара, Дата_размещения, Стоимость FROM Заказы INNER JOIN Товары ON Заказы.id_товара = Товары.id_товара where id_клиента = '{LOGIN}'");

            listGoods.ItemsSource = table.DefaultView;

            System.Data.DataTable summ = SQLbase.Select($"select SUM(Стоимость) from Заказы INNER JOIN Товары ON Заказы.id_товара = Товары.id_товара where id_клиента = '{LOGIN}'");

            orderPrice.Content = $"Сумма заказа: {summ.Rows[0][0]}";
        }

        private void GoToGoods(object sender, RoutedEventArgs e)
        {
            Goods o = new Goods(LOGIN);
            this.Close();
            o.Show();
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

            System.Data.DataTable table = SQLbase.Select($"SELECT Заказы.id_товара, Название_товара, Дата_размещения, Стоимость FROM Заказы INNER JOIN Товары ON Заказы.id_товара = Товары.id_товара where id_клиента = '{LOGIN}'");

            DataRowView i = (DataRowView)listGoods.Items[x];
            SQLbase.Insert($"delete Заказы where id_заказа = N'{i.Row.ItemArray[0].ToString()}'");
            
            ShowList();
        }

        private void End(object sender, RoutedEventArgs e)
        {
            {
                Thread t = new Thread(ReportGo);
                t.Start();
            }

            void ReplaceWordStub(String stubToReplace, String Text, Word.Document word)
            {
                var range = word.Content;
                range.Find.ClearFormatting();
                range.Find.Execute(FindText: stubToReplace, ReplaceWith: Text);
            }

            MessageBox.Show("Чек сформирован.");
            this.Close();
            void ReportGo()
            {
                System.Data.DataTable table = SQLbase.Select($"select * from Orders inner join Goods on Orders.good = Goods.name where login = N'{LOGIN}'");

                var word = new Word.Application();
                word.Visible = false;
                // word.Document worddoc;

                //ReplaceWordStub("{nazv}", TableString(table), worddoc);
                var worddoc = word.Documents.Open(Environment.CurrentDirectory + "\\netcoreapp3.1\\Shablon.docx");

                try
                {
                    Word.Table t = worddoc.Tables[1];

                    for (int i = 0, count = 2;
                    i < table.Rows.Count;

                    i++, count++)
                    {
                        t.Cell(count, 1).Range.Text = table.Rows[i][0].ToString();
                        t.Cell(count, 2).Range.Text = table.Rows[i][1].ToString();
                        t.Cell(count, 3).Range.Text = table.Rows[i][4].ToString();
                        if (count < table.Rows.Count + 1) t.Rows.Add();
                    }

                    worddoc.SaveAs2(Environment.CurrentDirectory + "\\netcoreapp3.1\\Заказ.docx");

                    System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\netcoreapp3.1\\Заказ.docx");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
                finally
                {
                    worddoc.Close();
                }
            }
        }
    }
}
