using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;


namespace WPFMachineStatus.Utils
{
    public class JSettings
    {
        public class MachineSettings
        {
            public List<string> MachineStatus { get; set; }
        }

        public List<string> ReadSettingsFromFile(string filePath)
        {
            try
            {
                // Read the JSON file
                string jsonString = File.ReadAllText(filePath);

                // Deserialize JSON to MachineSettings object
                MachineSettings machineSettings = JsonConvert.DeserializeObject<MachineSettings>(jsonString);

                // Return the MachineStatus list
                return machineSettings.MachineStatus;
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine("Error reading JSON file: " + ex.Message);
                // Return an empty list if there's an error
                return new List<string>(); 
            }
        }
    }
}
