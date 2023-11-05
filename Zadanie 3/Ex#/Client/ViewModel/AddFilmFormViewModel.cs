using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Client.Model;
using Client.Services;

namespace Client.ViewModel
{
    public partial class AddFilmFormViewModel : ObservableObject
    {
        private IAddFilmService _addFilmService;

        private ObservableCollection<FilmModel> _films;

        [ObservableProperty]
        private FilmViewModel selectedFilm;

        public AddFilmFormViewModel(IAddFilmService filmSearchService)
        {
            _addFilmService = filmSearchService;
        }

        [RelayCommand]
        public void PutFilm()
        {
            FilmModel film = selectedFilm.toFilmModel();
            if (selectedFilm.Id != null){
                _addFilmService.UpdateFilm(selectedFilm.toFilmModel());
            } else{
                _addFilmService.AddFilm(selectedFilm.toFilmModel());
            }
        }
    }
}