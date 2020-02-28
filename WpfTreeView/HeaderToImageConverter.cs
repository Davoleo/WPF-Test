using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WpfTreeView.Directory;

namespace WpfTreeView
{
    /// <summary>
    /// Converts a full path to a specific image (drive, folder or file)
    /// </summary>
    [ValueConversion(typeof(string), typeof(BitmapImage))]
    class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var path = (string) value;

            if (path == null)
                return null;

            //Get the name of the file/folder/drive
            var name = DirectoryStructure.GetFileFolderName(path);

            //Presume a file by default
            var image = "Images/file.png";

            //If the name is blank, we presume it's a drive because folders of files with no name can't exist
            if (string.IsNullOrEmpty(name))
            {
                image = "Images/disc.png";
            } else if (new FileInfo(path).Attributes.HasFlag(FileAttributes.Directory))
            {
                image = "Images/folder.png";
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
