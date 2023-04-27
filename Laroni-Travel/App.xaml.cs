using Laroni_Travel.View;
using Laroni_Travel.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Laroni_Travel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var vm = new InlogViewModel();
            var view = new InlogView();
            view.DataContext = vm;
            view.Show();
        }
    }
}