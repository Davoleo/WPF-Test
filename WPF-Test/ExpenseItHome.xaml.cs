using System.Windows;
using System.Windows.Controls;

namespace WPF_Test
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Page
    {
        public ExpenseItHome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ExpenseReportPage reportPage = new ExpenseReportPage(this.PeopleListBox.SelectedItems);
            this.NavigationService.Navigate(reportPage);
        }
    }
}
