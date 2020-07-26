using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;

namespace WPF_Test.Windows
{
    /// <summary>
    /// Interaction logic for MenuBars.xaml
    /// </summary>
    public partial class MenuBars : Window
    {
        public MenuBars()
        {
            InitializeComponent();
        }

        private void MenuOpen_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
        }

        private void MenuSave_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.ShowDialog();
        }

        private void MenuItemFontTimes_OnClick(object sender, RoutedEventArgs e)
        {
            MenuItemFontConsolas.IsChecked = false;
            MenuItemFontArial.IsChecked = false;
            TextBoxEditor.FontFamily = new FontFamily("Times New Roman");
        }

        private void MenuItemFontConsolas_OnClick(object sender, RoutedEventArgs e)
        {
            MenuItemFontTimes.IsChecked = false;
            MenuItemFontArial.IsChecked = false;
            TextBoxEditor.FontFamily = new FontFamily("Consolas");
        }

        private void MenuItemFontArial_OnClick(object sender, RoutedEventArgs e)
        {
            MenuItemFontTimes.IsChecked = false;
            MenuItemFontConsolas.IsChecked = false;
            TextBoxEditor.FontFamily = new FontFamily("Arial");
        }

        private void MenuExit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool comboIsClosed = true;

        private void ChangeFontSize()
        {
            string fontSize = comboFontSize.SelectedItem.ToString();
            fontSize = fontSize.Substring(fontSize.Length - 2);
            if (TextBoxEditor != null)
                TextBoxEditor.FontSize = Int32.Parse(fontSize);
        }

        private void ComboFontSize_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboIsClosed)
                ChangeFontSize();
            comboIsClosed = true;
        }

        private void ComboFontSize_OnDropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            comboIsClosed = !comboBox.IsDropDownOpen;
            ChangeFontSize();
        }
    }
}
