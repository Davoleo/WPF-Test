using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
        }

        private void Calendar_OnSelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var calendar = sender as Calendar;
            if (calendar.SelectedDate.HasValue)
            {
                DateTime date = calendar.SelectedDate.Value;
                try
                {
                    TextBoxDate.Text = date.ToShortDateString();
                }
                catch (NullReferenceException exception)
                {
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
    }
}
