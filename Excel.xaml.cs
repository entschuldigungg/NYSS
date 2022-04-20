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

namespace Appyyy
{
    /// <summary>
    /// Логика взаимодействия для Excel.xaml
    /// </summary>
    public partial class Excel : System.Windows.Window
    {
        IExcelDataReader edr;
       

        public Excel()
        {
            InitializeComponent();
        }


        private void Down(object sender, RoutedEventArgs e)
        {
            //var metrics = Metric.EnumerateMetrics(@"X:\DOWNLOADS\thrlist.xlsx").ToList();
            //Gridecc.ItemsSource = metrics;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "EXCEL Files (*.xlsx)|*.xlsx|EXCEL Files 2003 (*.xls)|*.xls|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != true)
                return;

            Gridecc.ItemsSource = ReadFile(openFileDialog.FileName);
        }

        public DataView ReadFile(string fileNames)
        {

            var extension = fileNames.Substring(fileNames.LastIndexOf('.'));
            // Создаем поток для чтения.
            FileStream stream = File.Open(fileNames, FileMode.Open, FileAccess.Read);
            // В зависимости от расширения файла Excel, создаем тот или иной читатель.
            // Читатель для файлов с расширением *.xlsx.
            if (extension == ".xlsx")
                edr = ExcelReaderFactory.CreateOpenXmlReader(stream);
            // Читатель для файлов с расширением *.xls.
            else if (extension == ".xls")
                edr = ExcelReaderFactory.CreateBinaryReader(stream);

            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration
                {
                    UseHeaderRow = true
                }
            };
            // Читаем, получаем DataView и работаем с ним как обычно.
            DataSet dataSet = edr.AsDataSet(conf);
            DataView dtView = dataSet.Tables[0].AsDataView();
            
            // После завершения чтения освобождаем ресурсы.
            edr.Close();
            return dtView;

        }
        
        
        private void Klein_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Excekklein excelWindow1 = new Excekklein();
            excelWindow1.Show();
        }


        private void Closation(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

       









        //    private void OnPreviousClicked(object sender, RoutedEventArgs e)
        //    {
        //        dtView.MoveToPreviousPage();
        //    }

        //    private void OnNextClicked(object sender, RoutedEventArgs e)
        //    {
        //        this._cview.MoveToNextPage();
        //    }
    }
}
    