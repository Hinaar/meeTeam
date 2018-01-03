using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hu-HU");

            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            MainViewModel mainViewModel = MainViewModel.Instance;


            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();

        }
    }
}
