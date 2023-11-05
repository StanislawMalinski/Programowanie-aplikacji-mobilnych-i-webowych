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
using Client.Commands;

namespace Client.ViewModel
{
    public partial class AddFilmFormViewModel : ObservableObject
    {
        private IAddFilmService _addFilmService;

        [ObservableProperty]
        private FilmViewModel? selectedFilm;

        public AddFilmFormViewModel(IAddFilmService filmSearchService)
        {
            _addFilmService = filmSearchService;
        }

        [RelayCommand]
        public void PutFilm()
        {
            if (SelectedFilm == null)
                return;
            FilmModel film = SelectedFilm.toFilmModel();
            if (SelectedFilm.Id > 0){
                _addFilmService.UpdateFilm(SelectedFilm.toFilmModel());
            } else{
                _addFilmService.AddFilm(SelectedFilm.toFilmModel());
            }
        }
    }
}