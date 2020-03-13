using System.Collections.ObjectModel;
using System.Linq;

namespace WpfTreeView.Directory.ViewModels
{

    /// <summary>
    /// View Model for the application main tree view
    /// </summary>
    class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        #endregion

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DirectoryStructureViewModel()
        {
            //Get the logical Drives
            var children = DirectoryStructure.GetLogicalDrives();

            //Create view models from the data
            Items = new ObservableCollection<DirectoryItemViewModel>(
                children.Select(drive => new DirectoryItemViewModel(drive.FullPath, drive.Type))
            );
        }

    }
}
