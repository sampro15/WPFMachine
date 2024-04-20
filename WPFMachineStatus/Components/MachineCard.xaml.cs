using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WPFMachineStatus.Components
{
   
    public partial class MachineCard : UserControl
    {

        // Define properties for binding
        public string MachineName
        {
            get { return (string)GetValue(MachineNameProperty); }
            set { SetValue(MachineNameProperty, value); }
        }
        //
        public string Description
        {
            get { return (string)GetValue(MachineDescriptionProperty); }
            set { SetValue(MachineDescriptionProperty, value); }
        }
        //
        public string Status
        {
            get { return (string)GetValue(MachineStatusProperty); }
            set { SetValue(MachineStatusProperty, value); }
        }
        //
        public string Notes
        {
            get { return (string)GetValue(MachineNotesProperty); }
            set { SetValue(MachineNotesProperty, value); }
        }
        //
        public string StatusIconPath
        {
            get { return (string)GetValue(StatusIconPathProperty); }
            set { SetValue(StatusIconPathProperty, value); }
        }

        public MachineCard()
        {
            InitializeComponent();
        }

        // Dependency properties for binding
        public static readonly DependencyProperty MachineNameProperty =
            DependencyProperty.Register("MachineName", typeof(string), typeof(MachineCard), new PropertyMetadata(""));

        public static readonly DependencyProperty MachineDescriptionProperty =
    DependencyProperty.Register("Description", typeof(string), typeof(MachineCard), new PropertyMetadata(""));

        public static readonly DependencyProperty MachineStatusProperty =
    DependencyProperty.Register("Status", typeof(string), typeof(MachineCard), new PropertyMetadata(""));

        public static readonly DependencyProperty MachineNotesProperty =
    DependencyProperty.Register("Notes", typeof(string), typeof(MachineCard), new PropertyMetadata(""));

        public static readonly DependencyProperty StatusIconPathProperty =
            DependencyProperty.Register("StatusIconPath", typeof(string), typeof(MachineCard), new PropertyMetadata(""));

    }

  
}

