using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Measurements
    {
        public int MeasurementsID  { get; set; }
        public int SensorID { get; set; }
        public double Value { get; set; }
        public DateTime Time { get; set; }
    }
}
