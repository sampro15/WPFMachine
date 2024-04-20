using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMachineStatus.Models
{
    public class MachineModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public string StatusIconPath
        {
            get
            {
                return getIMGPath(Status);
            }
        }


        public MachineModel(string name, string description, string status, string notes)
        {
            Name = name;
            Description = description;
            Status = status;
            Notes = notes;
        }

        //help func to convers string to iconPath
        private string getIMGPath(string status)
        {

            if (status != null || status != string.Empty)
            {
                return $"/Icons/{status}.png";
            }
            return null;
        }
    }
}
