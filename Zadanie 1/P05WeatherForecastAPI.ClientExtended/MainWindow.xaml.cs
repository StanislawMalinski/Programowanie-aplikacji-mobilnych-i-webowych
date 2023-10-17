using P05WeatherForecastAPI.ClientExtended.Models;
using P05WeatherForecastAPI.ClientExtended.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P05WeatherForecastAPI.ClientExtended
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccuWeatherService accuWeatherService;

        public MainWindow()
        {
            InitializeComponent();
            accuWeatherService = new AccuWeatherService();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if(txtCity.Text != "")
            {
                City[] cities = await accuWeatherService.GetLocations(txtCity.Text);
                lbData.ItemsSource = cities;
                return;
            }

            string key;
            string tempValueCity;
            double tempValueWeather;

            if(txtIP.Text != "")
            {
                var ip = await accuWeatherService.GetCurrentLocationFromIP(txtIP.Text);
                if (ip == null){return;}    
                key = ip.Key;
                var weather  = await accuWeatherService.GetCurrentConditions(key);

                tempValueCity = ip.LocalizedName;
                tempValueWeather = weather.Temperature.Metric.Value;

                txtCity.Text = tempValueCity;
                txtLatLon.Text = Convert.ToString(ip.GeoPosition.Latitude).Replace(",", ".") + "," + 
                Convert.ToString(ip.GeoPosition.Longitude).Replace(",", "."); 
            } else if(txtLatLon.Text != "")
            {
                var geopos= await accuWeatherService.GetCurrentLocationFromGeoposition(txtLatLon.Text);
                if (geopos == null){return;}
                key = geopos.Key;
                var weather  = await accuWeatherService.GetCurrentConditions(key);

                tempValueCity = geopos.LocalizedName;
                tempValueWeather = weather.Temperature.Metric.Value;

                txtCity.Text = tempValueCity;
            } else {
                return;
            }

            lblCityName.Content = tempValueCity;
            lblTemperatureValue.Content = Convert.ToString(tempValueWeather);
            setWindow(key);
        }

        private async void setForcast(string key){
            DailyForecast forecast = await accuWeatherService.GetForcastForOneDay(key);
            if (forecast == null){return;}
            lblWeatherForcast.Content = forecast.Day.IconPhrase;
        }

        private async void setNeighbours(string key){
            City[] cities = await accuWeatherService.GetNeighbouredCity(key);
            lbData.ItemsSource = cities;
        }

        private async void setHistory(string key){
            WeatherInfo history = await accuWeatherService.GetWeatherHistory(key);
            lblWeatherHistory.Content = history.WeatherText;
        }

        private void setWindow(string key){
            setForcast(key);
            setNeighbours(key);
            setHistory(key);
        }

        private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity = (City) lbData.SelectedItem;
            if(selectedCity != null)
            {
                var weather = await accuWeatherService.GetCurrentConditions(selectedCity.Key);
                lblCityName.Content = selectedCity.LocalizedName;
                double tempValue = weather.Temperature.Metric.Value;
                lblTemperatureValue.Content = Convert.ToString(tempValue);
                setWindow(selectedCity.Key);
            }
        }
    }
}
