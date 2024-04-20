using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMachineStatus.Models;
using WPFMachineStatus.Utils;
using WPFMachineStatus.Views;

namespace WPFMachineStatus.ViewModels
{

    public class MainViewModel : INotifyPropertyChanged
    {

        private List<MachineModel> machineStatuses;
        public ObservableCollection<MachineModel> filteredMachineStatuses { get; set; }
        public ObservableCollection<string>? ValidStatuses { get; set; }

        private string _windowTitle;
        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                if (_windowTitle != value)
                {
                    _windowTitle = value;
                    OnPropertyChanged("WindowTitle");
                }
            }
        }

        private int _cb_index;
        public int cb_index
        {
            get { return _cb_index; }
            set
            {
                if (_cb_index != value)
                {
                    _cb_index = value;
                    OnPropertyChanged("cb_index");
                }
            }
        }
        public int SelectedMachineIndex { get; set; }  
        
        private bool isCardDisplay;
        public bool IsCardDisplay
        {
            get { return isCardDisplay; }
            set
            {
                if (isCardDisplay != value)
                {
                    isCardDisplay = value;

                    // Notidy list and card views
                    cardDisplay = isCardDisplay ? Visibility.Visible : Visibility.Hidden;
                    listDisplay = isCardDisplay ? Visibility.Hidden : Visibility.Visible;

                    OnPropertyChanged(nameof(IsCardDisplay));
                    OnPropertyChanged(nameof(CardDisplay));
                    OnPropertyChanged(nameof(ListDisplay));
                }
            }
        }

        private Visibility cardDisplay;
        public Visibility CardDisplay { get=> cardDisplay; }

        private Visibility listDisplay;

        public Visibility ListDisplay { get => listDisplay; }



        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainViewModel()
        {
            InitializeMachineStatuses();
            InitializeValidStatuses();
            cb_index = 0;

            cardDisplay = Visibility.Hidden;
        }




        // Methods
        private void InitializeMachineStatuses()
        {
            // Initialize default machines - best way is load it from JSON like the valid statuses. 
            machineStatuses = new List<MachineModel>
            {
                new MachineModel("Machine 1", "Description 1", "Running", "Notes 1"),
                new MachineModel("Machine 2", "Description 2", "Idle", "Notes 2"),
                new MachineModel("Machine 3", "Description 3", "Offline", "Notes 3")
            };
            //display all machines
            filteredMachineStatuses = new ObservableCollection<MachineModel>(machineStatuses);
        }

        public List<string> machineStatusList;

        private void InitializeValidStatuses()
        {
            // Read JSON file and store data into JSettings object
            JSettings jSettings = new JSettings();

            // Provide the path to your JSON file
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

            // Call the ReadSettingsFromFile fonc to get avalible machine status list
            machineStatusList = jSettings.ReadSettingsFromFile(jsonFilePath);

            //add "All" for the filter 
            List<string> allStatuses = new List<string> { "All" };
            allStatuses.AddRange(machineStatusList);

            // Create an ObservableCollection<string> from the new list
            ValidStatuses = new ObservableCollection<string>(allStatuses);
        }



        //help function
        public void UpdateListView(List<MachineModel> filteredMachines)
        {
            filteredMachineStatuses.Clear();

            foreach (var machine in filteredMachines)
            {
                filteredMachineStatuses.Add(machine); // Add machines back to the Items collection
            }
        }


        #region  functions for events
        public void AddNewMachine()
        {

            // Open a dialog to add a new machine
            MachineStatusDialog dialog = new MachineStatusDialog();
            //lock the main page
            if (dialog.ShowDialog() == true)
            {
                // Add the new machine status to the list
                machineStatuses.Add(dialog.MachineStatus);
                // Rebind the list to update the ListView
                UpdateListView(machineStatuses);
                //select from combobox "All" after adding new machine
                cb_index = 0; 
                //notify that new machene added
                MessageBox.Show(dialog.MachineStatus.Name + " was added.", "New machine added successfully", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        public void EditMachine()
        {

            // Check if a machine status is selected
            if (SelectedMachineIndex != -1) 
            {
                MachineModel selectedMachine = filteredMachineStatuses[SelectedMachineIndex];

                // Open a dialog to edit the selected machine
                MachineStatusDialog dialog = new MachineStatusDialog(selectedMachine);
                if (dialog.ShowDialog() == true)
                {
                    // Update the selected machine with the edited values
                    machineStatuses[SelectedMachineIndex] = dialog.MachineStatus;
                    //select from combobox "All" after Editing machine
                    cb_index = 0;
                    // Rebind the list to update the ListView
                    UpdateListView(machineStatuses);
                    MessageBox.Show(dialog.MachineStatus.Name + " was updated.", "Update successfully", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            else
            {
                MessageBox.Show("Please select a machine status to edit.");
            }
        }

        public void DeleteMachine()
        {

            // Check if a machine status is selected
            if (SelectedMachineIndex != -1)
            {
                // Prompt the user for confirmation
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this machine ?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    // Remove the selected machine from the list
                    machineStatuses.RemoveAt(SelectedMachineIndex);
                    //select from combobox "All" after Deleting new machine
                    cb_index = 0;
                    // update the ListView
                    UpdateListView(machineStatuses);

                }
            }
            else
            {
                MessageBox.Show("Please select a machine to delete.");
            }
        }

        public void FilterMachineStatuses()
        {
            //get the selected filter
            string selectedStatus = ValidStatuses[cb_index];

            if (selectedStatus == null || selectedStatus == "All")
            {
                UpdateListView(machineStatuses);
            }
            else
            {
                // Filter machines based on selected status
                List<MachineModel> filteredMachines = machineStatuses.Where(machine => machine.Status.Equals(selectedStatus, StringComparison.OrdinalIgnoreCase)).ToList();
                UpdateListView(filteredMachines);

            }
        }

        #endregion  functions for events




    }
}
