using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.model
{
    public class sensors
    {
        private int sensorID;
        private int nodeID;
        private string type;
        public int SensorID
        {
            get { return SensorID; }
            set { SensorID = value; }
        }

        public int NodeID
        {
            get { return NodeID; }
            set { NodeID = value; }
        }

        public string Type
        {
            get { return Type; }
            set { Type = value; }
        }
    }
}
