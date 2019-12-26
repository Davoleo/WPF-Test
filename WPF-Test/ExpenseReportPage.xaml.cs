using System.Windows.Controls;

namespace WPF_Test
{
    /// <summary>
    /// Interaction logic for ExpenseReportPage.xaml
    /// </summary>
    public partial class ExpenseReportPage : Page
    {
        public ExpenseReportPage()
        {
            InitializeComponent();
        }

        //Constructor to pass Report Data
        public ExpenseReportPage(object data) : this()
        {
            this.DataContext = data;
        }
    }
}
