using option_two.Entity.Model;

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

namespace option_two
{
    /// <summary>
    /// Логика взаимодействия для AddCard.xaml
    /// </summary>
    public partial class AddCard : Window
    {
        private bool isCreated { get; set; }
        private Entity.Model.Service GetService { get; set; }
       
        public AddCard()
        {
            InitializeComponent();
            isCreated = true;
        }
        public AddCard(Service service)
        {
            InitializeComponent();
            isCreated = false;
            GetService = service;
            Header.Text = "Изменение услуги";
            Edit.Content = "Изменить";
            DataContext = GetService;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string name = Name.Text;
            string duration = Duration.Text;
            string cost= Cost.Text;
            Cost.Text = cost.Substring(0, cost.Length-3).Trim();
            string sale= Sale.Text;
            if (name != "" && duration != "" && cost != "" && sale != "") {
                if (isCreated) {
                    Constants.Context.services.Add(new Service
                    {
                        Name= name,
                        Duration=Int32.Parse(duration),
                        Cost= decimal.Parse(cost),
                        Sale=Int32.Parse (sale)
                    });
                    Constants.Context.SaveChanges();
                    this.DialogResult = true;
                }
                else
                {
                    var element = Constants.Context.services.Find(GetService.Id);
                    if (element != null)
                    {
                        element.Name = name;
                        element.Duration = Int32.Parse(duration);
                        element.Cost = Convert.ToDecimal(cost); 
                        element.Sale=Int32.Parse(sale);
                    }
                    Constants.Context.SaveChanges();
                    this.DialogResult = true;

                }
            }
        }
    }
}
