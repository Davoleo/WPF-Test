namespace WpfTreeView.Directory.Data
{
    /// <summary>
    /// Information about a directory Item (A file, a drive or a folder)
    /// </summary>
    class DirectoryItem
    {
        /// <summary>
        /// The type of this directory Item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The absolute path to this directory Item
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// The name of this directory Item
        /// </summary>
        public string Name => this.Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath);
    }
}
