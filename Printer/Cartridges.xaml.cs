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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Printer
{
    /// <summary>
    /// Логика взаимодействия для Cartridges.xaml
    /// </summary>
    public partial class Cartridges : System.Windows.Controls.Page
    {
        PrintEntities printEntities = new PrintEntities();
        public Cartridges()
        {
            InitializeComponent();
            N6.ItemsSource = printEntities.Тонер.ToList();
            N6.DisplayMemberPath = "Макрка";
            N6.SelectedValuePath = "id_тонер";
            DataGrid();
        }
        private void DataGrid()
        {
            dataGrid.ItemsSource = printEntities.Картриджи.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            printEntities.SaveChanges();
            DataGrid();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Картриджи картриджи = new Картриджи()
            {
                Название = N1.Text,
                Тип_картриджа = N2.Text,
                Статус = N3.Text,
                Дата_заправки = N4.DisplayDate,
                Количество_заправок = N5.Text,
                id_тонер = int.Parse(N6.SelectedValue.ToString()),
            };
            printEntities.Картриджи.Add(картриджи);
            printEntities.SaveChanges();
            DataGrid();
            MessageBox.Show("Успешно");
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить?", "Оповещение ", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                    {
                        Картриджи картриджи = dataGrid.SelectedItems[i] as Картриджи;
                        printEntities.Картриджи.Remove(картриджи);
                    }
                    printEntities.SaveChanges();
                    DataGrid();
                    MessageBox.Show("Успешно");
                }
            }
            else
            {
                MessageBox.Show("Выберите запись или записи");
                return;
            }
        }

      
             
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog printObj = new PrintDialog();
            if (printObj.ShowDialog() == true)
            {

                printObj.PrintVisual(dataGrid, "");
            }
            else
            {
                MessageBox.Show("Пользователь прервал печать!");
            }
        }
    }
}

 

