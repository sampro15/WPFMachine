using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFMachineStatus.Models;
using WPFMachineStatus.Utils;
using WPFMachineStatus.ViewModels;


namespace WPFMachineStatus.Views
{

    public partial class MainWindow : Window
    {
        private const string SW_VER = "1.0";
        private readonly MainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            //DataContext = this;
            _viewModel = new MainViewModel();
            DataContext = _viewModel;
            _viewModel.WindowTitle = $"Machine Status Tracker Application - Version {SW_VER}";
        }

 
       
        #region Event handlers
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddNewMachine();
        }


        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.EditMachine();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteMachine();
        }

        private void cb_filter_changed(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.FilterMachineStatuses();
        }

        //event for scrolling when mouse inside the listbox
        private void machineCardView_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var listBox = (ListBox)sender;
            if (e.Delta > 0)
            {
                if (listBox.SelectedIndex > 0)
                    listBox.SelectedIndex--;
            }
            else
            {
                if (listBox.SelectedIndex < listBox.Items.Count - 1)
                    listBox.SelectedIndex++;
            }
            e.Handled = true;
        }
        #endregion Event handlers



    }
}
