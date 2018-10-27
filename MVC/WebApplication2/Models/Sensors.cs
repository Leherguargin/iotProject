using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.model
{
    public class Sensors
    {
        [Key]
        public int NodeID { get; set; }
        public int SensorID { get; set; }
        public string Type { get; set; }
    }
}



