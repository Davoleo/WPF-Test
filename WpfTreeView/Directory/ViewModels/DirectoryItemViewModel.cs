using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WpfTreeView.Directory.Data;

namespace WpfTreeView.Directory.ViewModels
{
    // More UI-Specific than the internal object
    class DirectoryItemViewModel
    {

        #region Public Properties

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

        /// <summary>
        /// The list of all the Children of this Directory Item
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }

        /// <summary>
        /// indicates whether this item can be expanded
        /// </summary>
        public bool CanExpand => Type != DirectoryItemType.File;

        /// <summary>
        /// Tells if the current item is expanded or not
        /// </summary>
        public bool IsExpanded
        {
            get { return Children.Count(item => item != null) > 0; }
            set
            {
                //if the UI tells us to expand
                if (value)
                    Expand();
                else
                    ClearChildren();
            }
        }

        #endregion

        #region Public Commands

        /// <summary>
        /// The command to expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        #endregion


        /// <summary>
        /// Default Constructor
        /// <param name="fullPath">The full path of this item</param>
        /// <param name="type">The Type of this item</param>
        /// </summary>
        public DirectoryItemViewModel(string fullPath, DirectoryItemType type)
        {
            //create the commands
            ExpandCommand = new RelayCommand(Expand);

            //set the properties
            FullPath = fullPath;
            Type = type;

            //Setup the children as needed
            ClearChildren();
        }

        /// <summary>
        /// Expands this item and finds all the children
        /// </summary>
        private void Expand()
        {
            if (Type == DirectoryItemType.File)
                return;

            //Find All the Children
            Children = new ObservableCollection<DirectoryItemViewModel>(
                DirectoryStructure.GetDirectoryContents(this.FullPath)
                    .Select(content => new DirectoryItemViewModel(content.FullPath, content.Type))
            );
        }

        #region Helper Methods

        /// <summary>
        /// Removes all children from the Observable Collection
        /// Adding a dummy item to show the arrow icon if necessary
        /// </summary>
        private void ClearChildren()
        {
            //Clears all the items of the old list by assigning a new empty list
            Children = new ObservableCollection<DirectoryItemViewModel>();

            //Show the expand arrow if type != File
            if (Type != DirectoryItemType.File )
                Children.Add(null);
        }

        #endregion
    }
}
