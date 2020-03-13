using System.ComponentModel;

namespace WpfTreeView.Directory.ViewModels
{
    /// <summary>
    /// A Base View Model that fires Property Changed Events
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when properties change value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};
    }
}
