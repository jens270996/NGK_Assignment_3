using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureAPI.Models
{
    public class Location
    {
        
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

        public List<Measurement> Measurements { get; set; }
    }
}
