using option_two.Entity.Model;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

namespace option_two
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void LoadData()
        {
            var list = Constants.Context.services.ToList();
            Catalog.ItemsSource = list;


        }
        public MainWindow()
        {
            InitializeComponent();
            LoadData();



            /*var lines = File.ReadAllLines(@"D:\\PB-41\2 вариант.txt").ToList();
            lines.RemoveAt(0);
            List<Service> services = new List<Service>();
            foreach (var line in lines) {
                var column = line.Split(',').Select(x=> x.Trim()).ToList();
                if (column[1].Contains("мин"))
                {
                    column[1] = (Int32.Parse(column[1].Substring(0, column[1].Length - 4)) * 60).ToString().Trim();
                }
                else
                {
                    column[1] = column[1].Substring(0, column[1].Length - 4);
                }
                var cost = column[2];
                if (cost.Contains("рублей"))
                {
                    column[2] = cost.Substring(0, cost.Length - 6).Trim();
                }
                else if (cost.Contains("руб."))
                {
                    column[2] = cost.Substring(0, cost.Length - 4).Trim();
                }
                else if(cost.Contains("₽")){
                    column[2] = cost.Substring(0, cost.Length - 1).Trim();
                }
                var sale = column[3];
                if (sale.Contains("нет"))
                {
                    column[3] = "0";
                }
                else
                {
                    column[3] = sale.Trim('%').Trim();
                }
                services.Add(
                    new Service
                    {
                        Name = column[0],
                        Duration = Int32.Parse(column[1].Trim()),
                        Cost = decimal.Parse(column[2].Trim()),
                        Sale = Int32.Parse(column[3].Trim())
                    }
                    );
            }

            Constants.Context.services.AddRange( services );
            Constants.Context.SaveChanges();*/
      
        }
        private void MenuItem_Delete1_Click(object sender, RoutedEventArgs e)
        {
            if (Catalog.SelectedIndex == -1) return;
            string msgtext = "Вы точно хотите удалить услугу?";
            string MessageName = "Последнее китайское предупреждение";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(msgtext, MessageName, button);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var element = Catalog.SelectedItem as Service;
                    if (element != null) { Constants.Context.services.Remove(element); }
                    Constants.Context.SaveChanges();
                    LoadData();
                    break;
                case MessageBoxResult.No:
                    break;
            }



        }
        private void MenuItem_Change1_Click(object sender, RoutedEventArgs e)
        {
            var element = Catalog.SelectedItem as Service;
            if (element == null) return;
            AddCard addCard = new AddCard(element);
            if (addCard.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void MenuItem_Add_Click(object sender, RoutedEventArgs e)
        {
            AddCard addCard = new AddCard();
            if (addCard.ShowDialog() == true)
            {
                LoadData();
            }
        }

        private void MenuItem_Ex_Click(object sender, RoutedEventArgs e)
        {
            var list = Constants.Context.services.ToList().Select(x => x.ToString());
            File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory+@"\export.txt", list);
            MessageBox.Show("Поздравляем", "Экспорт прошёл успешно");
        }

        private void MenuItem_Csv_Click(object sender, RoutedEventArgs e)
        {
            var list = Constants.Context.services.ToList().Select(x => x.ToString());
            File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory + @"\export.csv", list);
            MessageBox.Show("Поздравляем", "Экспорт прошёл успешно");
        }
    }
}
