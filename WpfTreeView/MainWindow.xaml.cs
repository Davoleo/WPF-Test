using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region OnLoaded

        /// <summary>
        /// Called when the application first opens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            //Get all the logical drives
            foreach (var drive in Directory.GetLogicalDrives())
            {
                //Create a new TreeViewItem for each Drive
                var item = new TreeViewItem()
                {
                    //Set the Header and the full path path of the TVITem
                    Header = drive,
                    Tag = drive
                };

                //Dummy Item
                item.Items.Add(null);

                //Listener to the OnExpand Event
                item.Expanded += Folder_Expanded;

                //Add Item to the TreeView
                FolderView.Items.Add(item);
            }
        }

        #region Folder Expanded Event

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {

            var expandedItem = (TreeViewItem) sender;

            //If there's no dummy item
            if (expandedItem.Items.Count != 1 || expandedItem.Items[0] != null)
                return;

            //Remove the dummy
            expandedItem.Items.Clear();

            //Full Path
            var path = (string) expandedItem.Tag;

            #region Get Folders

            //Blank list
            var directories = new List<string>();

            //Try to gather directories from the folder
            try
            {
                var dirs = Directory.GetDirectories(path);

                if (dirs.Length > 0)
                {
                    directories.AddRange(dirs);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            //for each Directory...
            directories.ForEach(dirPath =>
            {
                //Create the sub-dir Item
                var subItem = new TreeViewItem()
                {
                    //set its folder name
                    Header = GetFileFolderName(dirPath),

                    Tag = dirPath
                };

                //Add a dummy to allow folder expansion
                subItem.Items.Add(null);

                //Handle further expansion
                subItem.Expanded += Folder_Expanded;

                //Add Sub item to the parent
                expandedItem.Items.Add(subItem);
            });

            #endregion

            #region Get Files

            //Blank list
            var files = new List<string>();

            //Try to gather files from the folder
            try
            {
                var f = Directory.GetFiles(path);

                if (f.Length > 0)
                {
                    files.AddRange(f);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            //for each File...
            files.ForEach(filePath =>
            {
                //Create the sub-dir Item
                var subItem = new TreeViewItem()
                {
                    //set its file name
                    Header = GetFileFolderName(filePath),

                    Tag = filePath
                };

                //Add Sub item to the parent
                expandedItem.Items.Add(subItem);
            });



            #endregion
        }

        #endregion


        /// <summary>
        /// Find the file or the folder name from a full path
        /// </summary>
        /// <param name="path">the full path</param>
        /// <returns>everything after the last slash</returns>
        public static string GetFileFolderName(string path)
        {
            // "C:\Everything\Images" --> "Images"

            //return an empoty string if there's no path
            if (string.IsNullOrEmpty(path))
                return String.Empty;

            //Make sure all the slashes are backwards
            var normalizedPath = path.Replace('/', '\\');

            //Find the last backslash
            var lastEntryIndex = normalizedPath.LastIndexOf('\\');

            if (lastEntryIndex <= 0)
                return path;
            
            //Return everything after the last slash
            return path.Substring(lastEntryIndex + 1);
        }

        #endregion


    }
}
