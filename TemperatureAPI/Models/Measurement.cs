using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureAPI.Models
{
    public class Measurement
    {
        public int MeasurementId { get; set; }
        public DateTime Time { get; set; }
        public Location Location { get; set; }
        public double Temperature { get; set; }

        public string LocationName { get; set; }
        public int Humidity { get; set; }
        public double Pressure { get; set; }
    }
}
