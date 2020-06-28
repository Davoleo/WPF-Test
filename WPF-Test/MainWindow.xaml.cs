using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using WPF_Test.Windows;

namespace WPF_Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            //Initializes and runs the window when the application starts
            InitializeComponent();

            Title = "Home Window!";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void MainWindow_OnMouseMove(object sender, MouseEventArgs e)
        {
            MouseCoordsLabel.Content = e.GetPosition(this).ToString();
        }

        private void WindowCloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The App is Closing");
            Close();
        }

        private void ButtonOpenForm_OnClick(object sender, RoutedEventArgs e)
        {
            Order orderForm = new Order();
            orderForm.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuBars menuBarsForm = new MenuBars();
            menuBarsForm.Show();
        }
    }
}
