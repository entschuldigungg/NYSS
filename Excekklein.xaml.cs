using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Application = Microsoft.Office.Interop.Excel.Application;
using ExcelDataReader;
using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Dynamic;

namespace Appyyy
{
    /// <summary>
    /// Логика взаимодействия для Excekklein.xaml
    /// </summary>
    public partial class Excekklein : System.Windows.Window
    {
        

        public Excekklein()
        {
            InitializeComponent();
        }

            //Dictionary<string, string> klein = new Dictionary<string, string>();
            //for (int i = 0; i < arrData.Length; i++)

            //{
            //    klein.Add(arrData[i], arrData1[i]);
            //}
        

        

        private void Closation(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Generate_rows(object sender, AddingNewItemEventArgs e)
        {
            Application xlApp = new Application();

            Workbook xlWB = xlApp.Workbooks.Open(@"X:\DOWNLOADS\thrlist.xlsx");
            Worksheet xlSht = xlWB.Worksheets["Лист1"];
            //var 1
            string[] arrData = xlSht.Range["УБИ." + "A1"].CurrentRegion.Value;
            //string[] arrData1 = xlSht.Range["B1"].CurrentRegion.Value;

            DataGridTextColumn ident = new DataGridTextColumn();
            ident.Header = "идентификатор";
            ident.Binding = new Binding("идентификатор");
            ident.Width = 17;
            Gr.Columns.Add(ident);

            dynamic row = new ExpandoObject();

            for (int i = 0; i < 1; i++)
            {
                ((IDictionary<String, Object>)row)["идентификатор"] = arrData[i];

            }
           Gr.Items.Add(row);
        }




        private void Generate_rows1(object sender, AddingNewItemEventArgs e)
        {
            Application xlApp = new Application();

            Workbook xlWB = xlApp.Workbooks.Open(@"X:\DOWNLOADS\thrlist.xlsx");
            Worksheet xlSht = xlWB.Worksheets["Лист1"];
            //var 1
            //string[] arrData = xlSht.Range["УБИ." + "A1"].CurrentRegion.Value;
            string[] arrData1 = xlSht.Range["B1"].CurrentRegion.Value;

            DataGridTextColumn ident = new DataGridTextColumn();
            ident.Header = "идентификатор";
            ident.Binding = new Binding("идентификатор");
            ident.Width = 17;
            Gr1.Columns.Add(ident);

            dynamic row = new ExpandoObject();

            for (int i = 0; i < 1; i++)
            {
                ((IDictionary<String, Object>)row)["идентификатор"] = arrData1[i];

            }
            Gr1.Items.Add(row);
        }





        //    for (int i = 0; i < arrData1.Length; i++)
        //    {
        //        System.Data.DataTable dt = new System.Data.DataTable();
        //        DataRow row = dt.NewRow();
        //        row["Столбец №1"] = arrData1[i];
        //        dt.Rows.Add(row["Столбец №1"]);
        //        Gr1.Items.Add(dt);
        //    }
        //}
    }

}
