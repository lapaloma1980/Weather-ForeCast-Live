using System;

namespace OpenWeather
{
    public class Location
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string TimeZone { get; set; }
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }
}