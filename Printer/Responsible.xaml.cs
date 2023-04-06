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
    /// Логика взаимодействия для Responsible.xaml
    /// </summary>
    public partial class Responsible : Page
    {
        PrintEntities printEntities = new PrintEntities();
        public Responsible()
        {
            InitializeComponent();
            DataGrid();
        }
        private void DataGrid()
        {
            dataGrid.ItemsSource = printEntities.Ответственные.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            printEntities.SaveChanges();
            DataGrid();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Ответственные ответственные = new Ответственные()
            {
                Фамилия = N1.Text,
                Имя = N2.Text,
                Отчество = N3.Text,
                Дожность = N4.Text,
                Телефон = N5.Text,
            };
            printEntities.Ответственные.Add(ответственные);
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
                        Ответственные отвественные = dataGrid.SelectedItems[i] as Ответственные;
                        printEntities.Ответственные.Remove(отвественные);
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
