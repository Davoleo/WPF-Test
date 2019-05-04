using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_Test
{
    /// <summary>
    /// Logica di interazione per App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Models.PeopleService peopleService = new Models.PeopleService();
            ViewModels.MainWindowViewModel mainWindowViewModel = new ViewModels.MainWindowViewModel(peopleService);

            MainWindow main = new MainWindow(mainWindowViewModel);
            main.Show();
        }
    }
}
