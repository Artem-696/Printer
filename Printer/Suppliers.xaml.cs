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
    /// Логика взаимодействия для Suppliers.xaml
    /// </summary>
    public partial class Suppliers : Page
    {
        PrintEntities printEntities = new PrintEntities();
        public Suppliers()
        {
            InitializeComponent();
            DataGrid();
        }
        private void DataGrid()
        {
            dataGrid.ItemsSource = printEntities.Поставщики.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            printEntities.SaveChanges();
            DataGrid();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Поставщики поставщики = new Поставщики()
            {
                Название_организации = N1.Text,
                ФИО_поставщика = N2.Text,
                Телефон = N3.Text,
                Адрес = N4.Text,
            };
            printEntities.Поставщики.Add(поставщики);
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
                        Поставщики поставщики = dataGrid.SelectedItems[i] as Поставщики;
                        printEntities.Поставщики.Remove(поставщики);
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
    

