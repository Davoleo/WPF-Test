using WpfTreeView.Directory.Data;

namespace WpfTreeView.Directory.ViewModels
{
    class DirectoryItemViewModel
    {
        /// <summary>
        /// The full path of the Directory Item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The type of this directory Item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The name of this directory Item
        /// </summary>
        public string Name => Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath);
    }
}
