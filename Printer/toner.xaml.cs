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

namespace Printer
{
    /// <summary>
    /// Логика взаимодействия для toner.xaml
    /// </summary>
    public partial class toner : Page
    {
        PrintEntities printEntities = new PrintEntities();
        public toner()
        {
            InitializeComponent();
            DataGrid();
        }
        private void DataGrid()
        {
            dataGrid.ItemsSource = printEntities.Тонер.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            printEntities.SaveChanges();
            DataGrid();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Тонер тонер = new Тонер()
            {
                Макрка = N1.Text,
                Тип_тонера = N2.Text,
                Количество = N3.Text,
                Дата_списания = N4.DisplayDate,
            };
            printEntities.Тонер.Add(тонер);
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
                        Тонер тонер = dataGrid.SelectedItems[i] as Тонер;
                        printEntities.Тонер.Remove(тонер);
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
    }
}

    

