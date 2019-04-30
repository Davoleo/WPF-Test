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

namespace WPF_Test
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private Models.IPeopleService peopleService = null;

        public MainWindow(Models.IPeopleService peopleService)
        {
            InitializeComponent();
            this.peopleService = peopleService;

            comboPeople.ItemsSource = peopleService.People;
            comboPeople.DisplayMemberPath = "Surname";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (comboPeople.SelectedItem != null)
            {
                Models.Person person = (Models.Person)comboPeople.SelectedItem;
                lblGreetings.Text = $"Cordiali Saluti {person.Name} {person.Surname}";
            }
        }
    }
}
