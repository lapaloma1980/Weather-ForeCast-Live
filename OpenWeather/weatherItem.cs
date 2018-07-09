using System;

/*
 * <time from="2018-07-07T12:00:00" to="2018-07-07T15:00:00">
      <symbol number="801" name="Ein paar Wolken" var="02d"></symbol>
      <precipitation></precipitation>
      <windDirection deg="330.003" code="NNW" name="North-northeast"></windDirection>
      <windSpeed mps="4.21" name="Gentle Breeze"></windSpeed>
      <temperature unit="celsius" value="26.2" min="24.1" max="26.2"></temperature>
      <pressure unit="hPa" value="1026.23"></pressure>
      <humidity value="51" unit="%"></humidity>
      <clouds value="Ein paar Wolken" all="12" unit="%"></clouds>
    </time>*/
namespace OpenWeather
{
    public class WeatherItem
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int IconNumber { get; set; }
        public string Icon { get; set; }
        public string Temperature { get; set; }
        public string TemperatureMin { get; set; }
        public string TemperatureMax { get; set; }
        public string TemperatureUnit { get; set; }
        public double Pressure { get; set; }
        public string PressureUnit { get; set; }
    }
}
