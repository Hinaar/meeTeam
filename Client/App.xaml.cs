﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
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
            var cultureinfo = CultureInfo.CurrentCulture.Name;
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;  

            base.OnStartup(e);

            MainWindow mainWindow = new MainWindow();
            MainViewModel mainViewModel = MainViewModel.Instance;


            mainWindow.DataContext = mainViewModel;
            mainWindow.Show();

        }
    }
}
