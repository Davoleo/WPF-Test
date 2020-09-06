using System.Windows;
using System.Windows.Controls;

namespace WPF_Test
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public Order()
        {
            InitializeComponent();
        }

        private void Window_OnLoaded(object sender, RoutedEventArgs e)
        {
            FinishComboBox_OnSelectionChanged(ComboFinish, null);
        }

        private void ButtonApply_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The Description is {this.TextboxDescription.Text}", "HEY", MessageBoxButton.OK);
        }

        private void ButtonReset_OnClick(object sender, RoutedEventArgs e)
        {
            CheckboxWeld.IsChecked = 
                CheckboxAssembly.IsChecked = 
                    CheckboxPlasma.IsChecked = 
                        CheckboxLaser.IsChecked = 
                            CheckboxPurchase.IsChecked = 
                                CheckboxLathe.IsChecked = 
                                    CheckboxDrill.IsChecked = 
                                        CheckboxFold.IsChecked = 
                                            CheckboxRoll.IsChecked = 
                                                CheckboxSaw.IsChecked = false;

        }

        private void Checkbox_OnChecked(object sender, RoutedEventArgs e)
        {
            TextboxDescription.Text += $"{((CheckBox) sender).Content}, ";
        }

        private void FinishComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox combo = (ComboBox) sender;

            if (TextBoxNote != null)
            {
                var selectedItem = (ComboBoxItem) combo.SelectedItem;
                TextBoxNote.Text = selectedItem.Content.ToString();
            }
        }

        private void TextBoxSupplierCode_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxPartNumber.Text = TextBoxSupplierCode.Text;
        }
    }
}
