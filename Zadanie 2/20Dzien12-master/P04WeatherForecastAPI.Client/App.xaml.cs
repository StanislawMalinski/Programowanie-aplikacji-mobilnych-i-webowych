using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.Services;
using P04WeatherForecastAPI.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace P04WeatherForecastAPI.Client
{
       public partial class App : Application
    {
        IServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAccuWeatherService, AccuWeatherService>();
            services.AddSingleton<IFavoriteCityService, FavoriteCityService>();
            services.AddSingleton<MainViewModelV4>();
            services.AddSingleton<FavoriteCityViewModel>();
            services.AddSingleton<HistoryViewModel>();
            services.AddSingleton<ForcastViewModel>();
           
            services.AddTransient<MainWindow>();
            services.AddTransient<FavoriteCitiesView>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

    }
}
