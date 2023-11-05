using System;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

using Client.Services;
using Client.ViewModel;
using Client.Windows;

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
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFilmClientService, FilmClientService>();
            services.AddSingleton<IAddFilmService, AddFilmService>();
            services.AddSingleton<IFilmSearchService, FilmSearchService>();

            services.AddSingleton<MainWindowViewModel>();

            services.AddTransient<SearchFilmForm>();
            services.AddTransient<AddFilmForm>();
            services.AddTransient<MainWindow>();    
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
