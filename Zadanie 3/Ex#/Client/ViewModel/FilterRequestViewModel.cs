using System.Collections.Generic;
using Client.Model;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModel
{
    public partial class FilterRequestViewModel : ObservableObject
    {
        public FilterRequestViewModel()
        {
        }
        
        public FilterRequestViewModel(FilterRequest filter)
        {
            YearLow = filter.YearLow;
            YearHigh = filter.YearHigh;
            Genre = filter.Genre;
            RatingLow = filter.RatingLow;
            RatingHigh = filter.RatingHigh;
            Actors = filter.Actors;
            Director = filter.Director;
        }

        public FilterRequest toFilterRequest(){
            return new FilterRequest(){
                YearLow = YearLow,
                YearHigh = YearHigh,
                Genre = Genre,
                RatingLow = RatingLow,
                RatingHigh = RatingHigh,
                Actors = Actors,
                Director = Director
            };
        }

        public int? YearLow { get; set; }
        public int? YearHigh { get; set; }
        public string? Genre { get; set; }
        public int? RatingLow { get; set; }
        public int? RatingHigh { get; set; }
        public List<string>? Actors { get; set; }
        public string? Director { get; set; }
    }
}