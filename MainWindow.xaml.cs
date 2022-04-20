using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Appyyy
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Downloadbutton(object sender, RoutedEventArgs e)
        {
            Process.Start("https://bdu.fstec.ru/files/documents/thrlist.xlsx");
            MessageBox.Show("Успешное выполнение операции!");
        }
        private void Openbutton(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Excel excelWindow = new Excel();
            excelWindow.Show();
            
        }
    }
}
