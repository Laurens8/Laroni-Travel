using Laroni_Travel.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Laroni_Travel.View
{
    /// <summary>
    /// Interaction logic for PersoonView.xaml
    /// </summary>
    public partial class PersoonView : Window
    {
        public PersoonView()
        {
            InitializeComponent();
        }

        private void lvNavbar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lviDashboard.IsSelected)
            {
                var vm = new HomeViewModel();
                var view = new HomeView();
                view.DataContext = vm;
                view.Show();
            }
            if (lviReizen.IsSelected)
            {
                var vm = new ReizenViewModel();
                var view = new ReizenView();
                view.DataContext = vm;
                view.Show();
                this.Close();
            }
            if (lviOpleidingen.IsSelected)
            {
                var vm = new OpleidingViewModel();
                var view = new OpleidingView();
                view.DataContext = vm;
                view.Show();
            }
            if (lviLogout.IsSelected)
            {
                var vm = new InlogViewModel();
                var view = new InlogView();
                view.DataContext = vm;
                view.Show();
            }
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}