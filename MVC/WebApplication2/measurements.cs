using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.model
{
    public class measurements
    {
        private int measurementsID;
        private int sensorID;
        private double value;
        private DateTime time;

        public int MeasurementsID
        {
            get { return MeasurementsID; }
            set { MeasurementsID = value; }
        }

        public int SensorID
        {
            get { return SensorID; }
            set { SensorID = value; }
        }

        public double Value
        {
            get { return Value; }
            set { Value = value; }
        }

        public DateTime Time
        {
            get { return Time; }
            set { Time = value; }
        }
    }
}
