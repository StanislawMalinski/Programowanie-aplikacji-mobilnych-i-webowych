using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using P04WeatherForecastAPI.Client.ViewModels;
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

namespace P04WeatherForecastAPI.Client{
    //MVVM

       public partial class MainWindow : Window
    {
        private readonly MainViewModelV4 _viewModel;
        public MainWindow(MainViewModelV4 viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            //accuWeatherService = new AccuWeatherService();
        }

        






        //AccuWeatherService accuWeatherService;
        //IAccuWeatherService _accuWeatherService;
        //public MainWindow(IAccuWeatherService accuWeatherService)
        //{
        
        
        
        //}

        //private async void btnSearch_Click(object sender, RoutedEventArgs e)
        //{

        

        
        
        
        

        
        
        //}

        //private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        
        
        
        
        
        
        
        
        //}
    }
}
