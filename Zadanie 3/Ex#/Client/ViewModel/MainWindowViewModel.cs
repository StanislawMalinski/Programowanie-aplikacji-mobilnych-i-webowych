using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Client.Model;
using Client.Services;
using Client.Windows;

namespace Client.ViewModel
{
    // przekazywanie wartosci do innego formularza 
    public partial class MainWindowViewModel : ObservableObject
    {
        private FilmViewModel _selectedFilm;
        private FilmModel _film;
        private readonly IFilmClientService _filmClientService;
        private IAddFilmService _addFilmService;
        private IFilmSearchService _filmSearchService;


        private readonly AddFilmForm _addFilmWindow;
        private readonly SearchFilmForm _searchWindow;


        public ObservableCollection<FilmViewModel> Films { get; set; }


        public MainWindowViewModel(IFilmClientService filmClientService , 
                                    IAddFilmService addFilmService, 
                                    IFilmSearchService filmSearchService)
        {
            _filmClientService = filmClientService;
            _addFilmService = addFilmService;
            _filmSearchService = filmSearchService;

            Films = new ObservableCollection<FilmViewModel>();
        }


        [ObservableProperty]
        private FilmViewModel filmView;

        public FilmViewModel SelectedFilm
        {
            get => _selectedFilm;
            set
            {
                if (value == null)
                    return;
                _selectedFilm = value;
                OnPropertyChanged();
                LoadFilm();
            }
        }

        private async void LoadFilm()
        {
            if (SelectedFilm != null)
            {
                _film = await _filmClientService.GetFilmById(SelectedFilm.Id);
                filmView = new FilmViewModel(_film);
            }
        }


        [RelayCommand]
        public async void LoadTopFilms()
        {
            var films = await _filmClientService.GetTop10();
            Films.Clear();
            foreach (var film in films)
                Films.Add(new FilmViewModel(film));
        }

        [RelayCommand]
        public async void GetAllFilms()
        {
            var films = await _filmClientService.GetAllFilms();
            Films.Clear();
            foreach (var film in films)
                Films.Add(new FilmViewModel(film));
        }

        [RelayCommand]
        public async void DeleteFilm(int id)
        {
            await _filmClientService.DeleteFilm(id);
        }

        [RelayCommand]
        public void OpenFilmSearchForm()
        {
            _searchWindow.Show();
        }

        [RelayCommand]
        public void OpenAddFilmWindow()
        {
           _addFilmService.SetFilm(new FilmViewModel());
           _addFilmWindow.Show();
        }

        [RelayCommand]
        public void OpenUpdateFilmWondow()
        {
            _addFilmService.SetFilm(filmView);
            _addFilmWindow.Show();
        }
    }
}
