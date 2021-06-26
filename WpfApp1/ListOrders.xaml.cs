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
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.Threading;

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

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Report(object sender, RoutedEventArgs e)
        {
            //DataTable table = SQLbase.Select($"select * from Orders");

            //var application = new Word.Application();

            //Word.Document document = application.Documents.Add();

            //foreach(var x in table.Rows)
            //{
            //    Word.Paragraph userParagrapth = document.Paragraphs.Add();
            //    Word.Range useRange = userParagrapth.Range;
            //    useRange.Text = x.ToString();
            //    userParagrapth.set_Style("Title");
            //    useRange.InsertParagraphAfter();
            //}

            Thread t = new Thread(ReportGo);
            t.Start();
        }

        private void ReplaceWordStub(String stubToReplace, String Text, Word.Document word)
        {
            var range = word.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: Text);
        }

        private void ReportGo()
        {
            DataTable table = SQLbase.Select($"select * from Orders");

            var word = new Word.Application();
            word.Visible = false;
            //  word.Document worddoc;

            //ReplaceWordStub("{nazv}", TableString(table), worddoc);
            var worddoc = word.Documents.Open($"{Environment.CurrentDirectory}/report.docx");
            try
            {
                Word.Table t = worddoc.Tables[1];

                for (int i = 0, count = 2; i < table.Rows.Count; i++, count++)
                {
                    t.Cell(count, 1).Range.Text = table.Rows[i][0].ToString();
                    t.Cell(count, 2).Range.Text = table.Rows[i][1].ToString();
                    t.Cell(count, 3).Range.Text = table.Rows[i][2].ToString();
                    t.Cell(count, 4).Range.Text = table.Rows[i][3].ToString();
                    if (count < table.Rows.Count + 1)
                        t.Rows.Add();
                }

                worddoc.SaveAs2($"{Environment.CurrentDirectory}/report1.docx");
                //word.ActiveDocument.Close();
                MessageBox.Show("Создан");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            //finally
            //{
            //    //worddoc.Close();
            //}
        }



        //private string TableString(DataTable table)
        //{
        //    StringBuilder str = new StringBuilder();

        //    for(int i = 0; i < table.Rows.Count; i++)
        //    {
        //        str.Append($"{table.Rows[i][0]}|{table.Rows[i][1]}|{table.Rows[i][2]}|{table.Rows[i][3]}\n");
        //    }
        //    return str.ToString();
        //}
    }
}
