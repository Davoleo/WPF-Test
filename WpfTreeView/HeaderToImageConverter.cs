using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WpfTreeView.Directory.Data;

namespace WpfTreeView
{
    /// <summary>
    /// Converts a full path to a specific image (drive, folder or file)
    /// </summary>
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Presume a file by default
            var image = "Images/file.png";

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Images/disc.png";
                    break;
                case DirectoryItemType.Folder:
                    image = "Images/folder.png";
                    break;
            }

            //WPF URI RELATIVE PATH TO THE PROJECT DIR pack://application:,,,/
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
