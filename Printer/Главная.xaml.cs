using Printer.ApplicationData;
using System;
using System.Collections.Generic;
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

namespace Printer
{
    /// <summary>
    /// Логика взаимодействия для Главная.xaml
    /// </summary>
    public partial class Главная : Window
    {
        public Главная()
        {
            InitializeComponent();
            AppFrame.framemain = frameMain;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.Navigate(new Cartridges());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        AppFrame.framemain.Navigate(new Responsible());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.Navigate(new Suppliers());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
         AppFrame.framemain.Navigate(new Repair());
        }

       

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.Navigate(new Printers());
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            AppFrame.framemain.Navigate(new toner());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
