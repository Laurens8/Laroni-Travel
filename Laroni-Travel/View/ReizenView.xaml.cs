using Laroni_Travel.ViewModels;
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
    /// Interaction logic for ReizenView.xaml
    /// </summary>
    public partial class ReizenView : Window
    {
        public ReizenView()
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
            if (lviPersonen.IsSelected)
            {
                var vm = new PersoonViewModel();
                var view = new PersoonView();
                view.DataContext = vm;
                view.Show();
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
    }
}