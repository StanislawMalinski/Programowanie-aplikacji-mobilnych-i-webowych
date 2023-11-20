using Microsoft.Extensions.DependencyInjection;
using Client.Services;
using Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Client
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
            _serviceProvider = service.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFilmClientService, FilmClientService>();
            services.AddSingleton<IAddFilmService, AddFilmService>();
            services.AddSingleton<IFilmSearchService, FilmSearchService>();

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<SearchFilmFormViewModel>();
            services.AddSingleton<AddFilmFormViewModel>();

            services.AddTransient<SearchFilmForm>();
            services.AddTransient<AddFilmForm>();
            services.AddTransient<MainWindow>();    
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            Console.WriteLine("OnStartup");
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
