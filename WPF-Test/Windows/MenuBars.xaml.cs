using System;
using System.Windows;
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
    }
}
