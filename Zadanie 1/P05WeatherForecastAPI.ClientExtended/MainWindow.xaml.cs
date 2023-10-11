﻿using P05WeatherForecastAPI.ClientExtended.Models;
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

            if(txtIP.Text != "")
            {
                var location = await accuWeatherService.GetCurrentLocationFromIP(txtIP.Text);
                var weather  = await accuWeatherService.GetCurrentConditions(location.Key);
                string tempValueC = location.LocalizedName;
                double tempValueW = weather.Temperature.Metric.Value;
                string tempValueG = Convert.ToString(location.GeoPosition.Latitude) + "," + Convert.ToString(location.GeoPosition.Longitude);
                txtLatLon.Text = tempValueG;
                lblCityName.Content = tempValueC;
                lblTemperatureValue.Content = Convert.ToString(tempValueW);
                return;
            }

            if(txtLatLon.Text != "")
            {
                var location = await accuWeatherService.GetCurrentLocationFromGeoposition(txtLatLon.Text);
                var weather  = await accuWeatherService.GetCurrentConditions(location.Key);
                string tempValueC = location.LocalizedName;
                double tempValueW = weather.Temperature.Metric.Value;
                lblCityName.Content = tempValueC;
                lblTemperatureValue.Content = Convert.ToString(tempValueW);
                return;
            }
        }

        private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity= (City) lbData.SelectedItem;
            if(selectedCity != null)
            {
                var weather = await accuWeatherService.GetCurrentConditions(selectedCity.Key);
                lblCityName.Content = selectedCity.LocalizedName;
                double tempValue = weather.Temperature.Metric.Value;
                lblTemperatureValue.Content = Convert.ToString(tempValue);
                string tempValueG = Convert.ToString(selectedCity.GeoPosition.Latitude) + "," + Convert.ToString(selectedCity.GeoPosition.Longitude);
                txtLatLon.Text = tempValueG;
            }
        }
    }
}
