using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Win32;

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

        private void ButtonOpenFile_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
        }

        private void ButtonOpenForm_OnClick(object sender, RoutedEventArgs e)
        {
            Order orderForm = new Order();
            orderForm.Show();
        }
    }
}
