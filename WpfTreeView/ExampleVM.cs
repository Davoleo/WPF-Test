using System.ComponentModel;
using System.Threading.Tasks;

namespace WpfTreeView
{
    class ExampleVm : INotifyPropertyChanged
    {
        //fire this each time a property you need has changed
        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };

        //Self Aware Property - it automatically fires the PropertyChanged Event once the content has changed (Thanks to PropertyChanged.Fody)
        public string Test { get; set; }

        /*
        Fody Automatically does this to call the event

        set
        {
            if (test == value)
                return;

            test = value;

            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Test)));
        }
        */

        public ExampleVm()
        {
            Task.Run(async () =>
            {
                int i = 0;
                while (true)
                {
                    await Task.Delay(200);
                    Test = (i++).ToString();
                    PropertyChanged(this, new PropertyChangedEventArgs("Test"));
                }
            });
        }
    }
}
