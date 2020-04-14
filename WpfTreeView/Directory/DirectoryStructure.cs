using System;
using System.Collections.Generic;
using System.Linq;
using WpfTreeView.Directory.Data;

namespace WpfTreeView.Directory
{
    /// <summary>
    /// Util Class to query directory information
    /// </summary>
    class DirectoryStructure
    {

        /// <summary>
        /// Get all the logical drives active on the computer
        /// </summary>
        /// <returns>A list of Drive Directory Items</returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
            return System.IO.Directory.GetLogicalDrives()
                .Select(drive => new DirectoryItem{FullPath = drive, Type = DirectoryItemType.Drive})
                .ToList();
        }

        /// <summary>
        /// Find the file or the folder name from a full path
        /// </summary>
        /// <param name="path">the full path</param>
        /// <returns>everything after the last slash</returns>
        public static string GetFileFolderName(string path)
        {
            // "C:\Everything\Images" --> "Images"

            //return an empoty string if there's no path
            if (String.IsNullOrEmpty(path))
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

        /// <summary>
        /// Gets the directories top-level content
        /// </summary>
        /// <param name="fullPath">The full path to the directory you want to get the content of</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            //Create an empty list for Directory Items
            var items = new List<DirectoryItem>();

            #region Get Folders

            //Try to gather directories from the folder
            try
            {
                var dirs = System.IO.Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem{FullPath = dir, Type = DirectoryItemType.Folder}));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            #endregion

            #region Get Files


            //Try to gather files from the folder
            try
            {
                var files = System.IO.Directory.GetFiles(fullPath);

                if (files.Length > 0)
                    items.AddRange(files.Select(file => new DirectoryItem{FullPath = file, Type = DirectoryItemType.File}));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            #endregion

            return items;
        }
    }
}
