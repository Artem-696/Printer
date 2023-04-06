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
    /// Логика взаимодействия для Printers.xaml
    /// </summary>
    public partial class Printers : System.Windows.Controls.Page
    {
        PrintEntities printEntities = new PrintEntities();
        public Printers()
        {
            InitializeComponent();
            N9.ItemsSource = printEntities.Поставщики.ToList();
            N9.DisplayMemberPath = "Название_организации";
            N9.SelectedValuePath = "id_поставщика";
            N10.ItemsSource = printEntities.Ответственные.ToList();
            N10.DisplayMemberPath = "Фамилия";
            N10.SelectedValuePath = "id_ответственные";
            N11.ItemsSource = printEntities.Картриджи.ToList();
            N11.DisplayMemberPath = "Название";
            N11.SelectedValuePath = "id_картриджа";



            DataGridUpdate();

        }
        private void DataGridUpdate()
        {
            dataGrid.ItemsSource = printEntities.Принтеры.ToList();
        }
        private void RefreshDG_Click(object sender, RoutedEventArgs e)
        {
            DataGridUpdate();
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItems.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить?", "Оповещение ",
                            MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    for (int i = 0; i < dataGrid.SelectedItems.Count; i++)
                    {
                        Принтеры принтеры = dataGrid.SelectedItems[i] as Принтеры;
                        printEntities.Принтеры.Remove(принтеры);
                    }
                    printEntities.SaveChanges();
                    DataGridUpdate();
                    MessageBox.Show("Успешно");
                }
            }
            else
            {
                MessageBox.Show("Выберите запись или записи");
                return;
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            printEntities.SaveChanges();
            DataGridUpdate();
        }
        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            Принтеры принтеры = new Принтеры()
            {
                Инвентарный_номер = N1.Text,
                Модель_принтера = N2.Text,
                Тип_принтера = N3.Text,
                Гарантия = N4.Text,
                Дата_покупки = N5.DisplayDate,
                Дата_списания = N6.DisplayDate,
                Статус = N7.Text,
                Кабинет = N8.Text,
                id_поставщика = int.Parse(N9.SelectedValue.ToString()),
                id_ответственные = int.Parse(N10.SelectedValue.ToString()),
                id_картриджи = int.Parse(N11.SelectedValue.ToString()),


            };
            printEntities.Принтеры.Add(принтеры);
            printEntities.SaveChanges();
            DataGridUpdate();
            MessageBox.Show("Успешно");
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

  

