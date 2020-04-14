using System.ComponentModel;

namespace WpfChatApp.ViewModel
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

        /// <summary>
        /// Call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
