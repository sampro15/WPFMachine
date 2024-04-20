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
using WPFMachineStatus.Models;
using WPFMachineStatus.ViewModels;

namespace WPFMachineStatus.Views
{
    /// <summary>
    /// Interaction logic for MachineStatusDialog.xaml
    /// </summary>
    public partial class MachineStatusDialog : Window
    {
        private readonly MainViewModel _viewModel;
        public MachineStatusDialog()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();

        }
        private List<string> validStatuses { get => _viewModel.machineStatusList; }


        public MachineStatusDialog(MachineModel machineStatus) : this()
        {
            // Initialize the dialog with the existing machine status data
            tb_name.Text = machineStatus.Name;
            tb_decription.Text = machineStatus.Description;
            tb_status.Text = machineStatus.Status;
            tb_notes.Text = machineStatus.Notes;
        }

        // Property to get the edited or newly added machine status
        public MachineModel MachineStatus { get; private set; }

        //help function
        private bool CheckStatusString(string status)
        {
            foreach (string validStatus in validStatuses)
            {
                if (status == validStatus)
                {
                    return true;
                }
            }
            return false;
        }

        // Event handler for the OK button click
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
 
            string Name = tb_name.Text;
            string Description = tb_decription.Text;
            string Status = tb_status.Text;
            string Notes = tb_notes.Text;
            // validate
            if (Name is null || Name == string.Empty)
            {
                MessageBox.Show("Machine name is required.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (Status is null || Status == string.Empty)
            {
                MessageBox.Show("Status  is required. \r\nStatus must be 'Running', 'Idle', or 'Offline'.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!CheckStatusString(Status))
            {
                MessageBox.Show("Invalid status value. Status must be 'Running', 'Idle', or 'Offline'.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create a new MachineStatus object with the entered data
            MachineStatus = new MachineModel(Name,Description, Status, Notes);

            // Close the dialog with DialogResult = true
            DialogResult = true;
            this.Close();
        }

        // Event handler for the Cancel button click
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the dialog with DialogResult = false
            DialogResult = false;
        }

        
    }
}
