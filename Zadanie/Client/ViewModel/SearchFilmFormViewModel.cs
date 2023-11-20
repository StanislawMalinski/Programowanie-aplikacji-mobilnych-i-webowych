using CommunityToolkit.Mvvm.ComponentModel;
using Shared.Model;
using Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModel
{
    public partial class SearchFilmFormViewModel : ObservableObject
    {
        private readonly IFilmSearchService _filmSearchService;

        private List<FilmModel> _films;

        [ObservableProperty]
        private FilmModel selectedCity;

        [ObservableProperty]
        private FilterRequestViewModel filter;

        public SearchFilmFormViewModel(IFilmSearchService filmSearchService)
        {
            _filmSearchService = filmSearchService;
        }

        public void filterFilms()
        {
            FilterRequest filterInst = Filter.toFilterRequest();
            List<FilmModel> films = _filmSearchService.SearchFilms(filterInst);
            _films = films;
        }
    }
}
