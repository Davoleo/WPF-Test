using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace WPF_Test.Windows
{
    /// <summary>
    /// Interaction logic for Tests2.xaml
    /// </summary>
    public partial class Tests2 : Window
    {
        public Tests2()
        {
            //Initializes and runs the window when the application starts
            InitializeComponent();

            Title = "Home Window!";
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            GenerateFlowDocument();
        }

        private void GenerateFlowDocument()
        {
            FlowDocument document = new FlowDocument();

            Paragraph paragraph = new Paragraph(new Run("akjdaksdhajsdhkasdhjkashajhkashdjkasdhajkshdajksdhajksdhajkshdakjsdhakjsdhajkdha"));

            document.Blocks.Add(paragraph);

            paragraph = new Paragraph(new Run(
                "test string number 22222222222222222222222222222222222222222222222222222222222222222222222"))
            {
                FontSize = 14,
                FontStyle = FontStyles.Italic,
                Foreground = Brushes.DarkSalmon
            };

            document.Blocks.Add(paragraph);

            FlowScrollViewer.Document = document;

        }

        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar.SelectedDate.HasValue)
            {
                DateTime date = calendar.SelectedDate.Value;
                if (TextBoxDate != null)
                {
                    TextBoxDate.Text = date.ToShortDateString();
                }
            }
        }

        private void DrawPanel_OnKeyUp(object sender, KeyEventArgs e)
        {
            int keyCode = (int) e.Key;

            if (keyCode >= 35 && keyCode <= 68)
            {
                switch (keyCode)
                {
                    case 35:
                        StrokeAttr.Width = 2;
                        StrokeAttr.Height = 2;
                        break;
                    case 36:
                        StrokeAttr.Width = 4;
                        StrokeAttr.Height = 4;
                        break;
                    case 37:
                        StrokeAttr.Width = 6;
                        StrokeAttr.Height = 6;
                        break;
                    case 38:
                        StrokeAttr.Width = 8;
                        StrokeAttr.Height = 8;
                        break;

                    case 45:
                        StrokeAttr.Color = Colors.Blue;
                        break;
                    case 50:
                        StrokeAttr.Color = Colors.Green;
                        break;
                    case 68:
                        StrokeAttr.Color = Colors.Yellow;
                        break;
                }

            }
        }

        private void DrawFunctionChanges(object sender, RoutedEventArgs e)
        {
            var clickedButton = sender as RadioButton;
            string buttonContent = clickedButton.Content.ToString();
            if (buttonContent == "Draw")
            {
                DrawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
            } 
            else if (buttonContent == "Erase")
            {
                DrawingCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
            } 
            else if (buttonContent == "Select")
            {
                DrawingCanvas.EditingMode = InkCanvasEditingMode.Select;
            }
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("picture.bin", FileMode.Create))
            {
                DrawingCanvas.Strokes.Save(fs);
            }
        }

        private void OpenButtonClick(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("picture.bin", FileMode.Open, FileAccess.Read))
            {
                StrokeCollection strokeCollection = new StrokeCollection(fs);
                DrawingCanvas.Strokes = strokeCollection;
            }
        }

        //Rich Textbox Methods
        private void RichTextBoxContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            RichTextBox textBox = sender as RichTextBox;

            if (textBox == null)
                return;

            ContextMenu contextMenu = textBox.ContextMenu;
            contextMenu.PlacementTarget = textBox;

            contextMenu.Placement = PlacementMode.RelativePoint;

            TextPointer position = textBox.Selection.End;

            if (position == null)
                return;

            Rect positionRect = position.GetCharacterRect(LogicalDirection.Forward);
            contextMenu.HorizontalOffset = positionRect.X;
            contextMenu.VerticalOffset = positionRect.Y;

            contextMenu.IsOpen = true;
        }

        private void SaveRichTextBoxContent(object sender, RoutedEventArgs e)
        {
            TextRange range = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);

            FileStream fs = new FileStream("E:\\C#Data\\richText.xaml", FileMode.Create);
            range.Save(fs, DataFormats.XamlPackage);
            fs.Close();
        }

        private void OpenRichTextBoxContent(object sender, RoutedEventArgs e)
        {
            TextRange range;
            FileStream fs;

            if (File.Exists("E:\\C#Data\\richText.xaml"))
            {
                range = new TextRange(RichTextBox.Document.ContentStart, RichTextBox.Document.ContentEnd);
                fs = new FileStream("E:\\C#Data\\richText.xaml", FileMode.OpenOrCreate);
                range.Load(fs, DataFormats.XamlPackage);
                fs.Close();
            }
        }

        #region Main Tab

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

        #endregion

        #region Menu Bars

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

        #endregion
    }
}
