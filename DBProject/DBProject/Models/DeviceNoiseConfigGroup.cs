using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class DeviceNoiseConfigGroup:BaseColumns
    {
        [Required]
        public string DeviceConfigGroupID { get; set; }
        [Required]
        public  string DeviceConfigGroupName { get; set; }
    }
}