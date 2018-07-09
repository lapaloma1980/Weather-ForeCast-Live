using System;
using System.Collections;
using System.Windows;
using System.Windows.Threading;

namespace Weather_Forecast_Live
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public OpenWeather.OpenWeather ow;
        public DispatcherTimer loadWeatherData;
        public MainWindow()
        {
            InitializeComponent();
            InitWeatherData();
            var loadWeatherData = new DispatcherTimer();
            loadWeatherData.Tick += new EventHandler(LoadWeatherData);
            loadWeatherData.Interval = new TimeSpan(0,0,5);
            loadWeatherData.Start();
        }

        private void LoadWeatherData(object sender, EventArgs e)
        {
            InitWeatherData();
        }
        private void InitWeatherData()
        {
            ow = new OpenWeather.OpenWeather();
            ow.load5DayForecast();
            wpHeader.DataContext = ow.CityData;
            lbToday.ItemsSource = (ArrayList)ow.weather[0];
            lbDayOne.ItemsSource = (ArrayList)ow.weather[1];
            lbDayTwo.ItemsSource = (ArrayList)ow.weather[2];
            lbDayThree.ItemsSource = (ArrayList)ow.weather[3];
            lbDayFour.ItemsSource = (ArrayList)ow.weather[4];
            
        }
       
    }
}
