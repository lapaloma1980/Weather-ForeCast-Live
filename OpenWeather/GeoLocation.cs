using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeather
{
    public class GeoLocation
    {
        public int Altitude { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Geobase { get; set; }
        public long GeobaseID { get; set; }
    }
}
