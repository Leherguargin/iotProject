using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenerowanieJsona.Models
{
    public class Measurements
    {
        public int MeasurementsID { get; set; }
        public int SensorID { get; set; }
        public double Value { get; set; }
        public DateTime Time { get; set; }

        public Measurements(int measurementsID, int sensorID, double value, DateTime time)
        {
            MeasurementsID = measurementsID;
            SensorID = sensorID;
            Value = value;
            Time = time;
        }
    }
}
