using System;

namespace LoraStore.Models
{
    public class Measurement
    {
        public Guid MeasurementId { get; set; }
        public DateTime MeasurementDate { get; set; }
        public decimal Value { get; set; }
        public int SensorId { get; set; }
    }
}