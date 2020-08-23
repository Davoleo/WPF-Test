using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;

namespace WPF_Test.Windows
{
    /// <summary>
    /// Interaction logic for Tests2.xaml
    /// </summary>
    public partial class Tests2 : Window
    {
        public Tests2()
        {
            InitializeComponent();

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
    }
}
