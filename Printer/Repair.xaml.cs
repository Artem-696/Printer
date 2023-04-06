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
    /// Логика взаимодействия для Repair.xaml
    /// </summary>
    public partial class Repair : Page
    {
        PrintEntities printEntities = new PrintEntities();
        public Repair()
        {
            InitializeComponent();
            N5.ItemsSource = printEntities.Неисправность.ToList();
            N5.DisplayMemberPath = "Описание";
            N5.SelectedValuePath = "id_неисправность";
            DataGrid();
        }
        private void DataGrid()
        {
            dataGrid.ItemsSource = printEntities.Ремонт.ToList();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            printEntities.SaveChanges();
            DataGrid();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Ремонт ремонт = new Ремонт()
            {
                Дата_ремонта = N1.DisplayDate,
                Описание_ремонта = N2.Text,
                Цена_ремонта = N3.Text,
                Модели_принтера = N4.Text,
                id_неисправность = int.Parse(N5.SelectedValue.ToString()),

            };
            printEntities.Ремонт.Add(ремонт);
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
                        Ремонт ремонт = dataGrid.SelectedItems[i] as Ремонт;
                        printEntities.Ремонт.Remove(ремонт);
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

