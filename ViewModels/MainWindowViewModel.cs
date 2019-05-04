using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Test.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Models.IPeopleService peopleService = null;
        private string greetings;

        public MainWindowViewModel(Models.IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        public IList<Models.Person> people => peopleService.People;

        public Models.Person SelectedPerson { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private string Greetings
        {
            get
            { return greetings; }

            set
            {
                greetings = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Greetings)));
            }
        }

        public void Greet()
        {
            if (SelectedPerson != null)
                Greetings = $"Greetings {SelectedPerson.Name} {SelectedPerson.Surname}";
        }
    }
}
