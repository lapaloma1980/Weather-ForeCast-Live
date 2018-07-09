using System;
using System.Collections;
using System.Xml.Linq;


namespace OpenWeather
{
    public class OpenWeather
    {
        public Location CityData { get; set; }
        public ArrayList weather = new ArrayList();
        

        private string _xmlForecastUrl = 
            @"https://api.openweathermap.org/data/2.5/forecast?q=duisburg,de&mode=xml&appid=f6961e11f89bf87d7bacc6ca47391a52&units=metric&lang=de";


        public void load5DayForecast()
        {

            XDocument weatherXDocument = XDocument.Load(_xmlForecastUrl);
            XElement cityLocation = weatherXDocument.Element("weatherdata").Element("location");
            XElement geoLocation = cityLocation.Element("location");
            XElement sun = weatherXDocument.Element("weatherdata").Element("sun");
            XElement forecastData = weatherXDocument.Element("weatherdata").Element("forecast");

            CityData = new Location();
            CityData.Name = cityLocation.Element("name").Value;
            CityData.Type = cityLocation.Element("type").Value;
            CityData.Country = cityLocation.Element("country").Value;
            CityData.TimeZone = cityLocation.Element("timezone").Value;
            CityData.Sunrise = GetDateTimeFromDateString(sun.Attribute("rise").Value);
            CityData.Sunset = GetDateTimeFromDateString(sun.Attribute("set").Value);

            CityData.GeoLocation = new GeoLocation();
            CityData.GeoLocation.Altitude = Convert.ToInt32(geoLocation.Attribute("altitude").Value);
            //CityData.GeoLocation.Latitude = cityLocation.Attribute("latitude").Value;
            //CityData.GeoLocation.Longitude = geoLocation.Attribute("longitude").Value;
            CityData.GeoLocation.Geobase = geoLocation.Attribute("geobase").Value;
            CityData.GeoLocation.GeobaseID = Convert.ToInt64(geoLocation.Attribute("geobaseid").Value);


            DateTime prvDateTime = new DateTime();
            bool isFirstRun = true;
            ArrayList weatherItemArrayList = new ArrayList();
            foreach (XElement item in forecastData.Elements("time"))
            {
                WeatherItem wItem = new WeatherItem();
                DateTime curDateTime = GetDateTimeFromDateString(item.Attribute("from").Value);
                if (!isFirstRun)
                {
                    if (curDateTime.Day > prvDateTime.Day || curDateTime.Month > prvDateTime.Month || curDateTime.Year > prvDateTime.Year)
                    {

                        weather.Add(weatherItemArrayList);
                        weatherItemArrayList = new ArrayList();
                    }
                }
                else
                {
                    isFirstRun = false;
                }

                wItem.From = curDateTime;
                wItem.To = GetDateTimeFromDateString(item.Attribute("to").Value);
                wItem.Icon = @"http://openweathermap.org/img/w/" + item.Element("symbol").Attribute("var").Value +
                             ".png";
                wItem.Temperature = item.Element("temperature").Attribute("value").Value;
                wItem.TemperatureMin = item.Element("temperature").Attribute("min").Value;
                wItem.TemperatureMax = item.Element("temperature").Attribute("max").Value;
                wItem.TemperatureUnit = (item.Element("temperature").Attribute("unit").Value == "celsius") ?"C":"F";
                weatherItemArrayList.Add(wItem);
                prvDateTime = curDateTime;
            }
        }

        private DateTime GetDateTimeFromDateString(string dateString)
        {
            string[] dateTime = dateString.Split('T');
            string[] date = dateTime[0].Split('-');
            string[] time = dateTime[1].Split(':');
            return new DateTime(Convert.ToInt32(date[0]), Convert.ToInt32(date[1]), Convert.ToInt32(date[2]), Convert.ToInt32(time[0]), 0, 0);
        }
    }
}
