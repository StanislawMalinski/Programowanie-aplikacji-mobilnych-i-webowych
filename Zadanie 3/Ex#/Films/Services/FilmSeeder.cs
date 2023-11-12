using System;
using System.Collections.Generic;
using Shared.Model;

namespace Films.Services
{
    public class FilmSeeder
    {
        private readonly Random _random = new Random();

        public List<FilmModel> GetRandomFilms(int count)
        {
            var films = new List<FilmModel>();

            for (int i = 0; i < count; i++)
            {
                var film = new FilmModel()
                {
                    Title = GetRandomTitle() + " " + GetPart(),
                    Director = GetRandomDirector(),
                    Year = GetRandomReleaseYear(),
                    Genre = GetRandomGenre(),
                    Rating = GetRandomRating(),
                    Actors = GetRandomActors(3)
                };

                films.Add(film);
            }

            return films;
        }

        public FilmModel GetFilm(string title){
            var film = GetRandomFilms(1).FirstOrDefault();
            film.Title = title;
            return film;
        }

        public List<FilmModel> GetRandomFilms(int count, FilterRequest filter)
        {
            var films = new List<FilmModel>();
            int low_year = filter.YearLow ?? 1900;
            int high_year = filter.YearHigh ?? 2022;
            int low_rating = filter.RatingLow ?? 0;
            int high_rating = filter.RatingHigh ?? 10;

            for (int i = 0; i < count; i++)
            {
                var film = new FilmModel()
                {
                    Title = GetRandomTitle() + " " + GetPart(),
                    Director = filter.Director?? GetRandomDirector(),
                    Year = GetRandomReleaseYear(low_year, high_year),
                    Rating =  GetRandomRating(low_rating, high_rating),
                    Genre = filter.Genre ?? GetRandomGenre(),
                    Actors = filter.Actors != null ? GetRandomActors(10, filter.Actors) : GetRandomActors(10)
                };

                films.Add(film);
            }

            return films;
        }

        private string GetRandomTitle()
        {
            var titles = new List<string>
            {
                "The Shawshank Redemption",
                "The Godfather",
                "The Dark Knight",
                "12 Angry Men",
                "Schindler's List",
                "The Lord of the Rings: The Return of the King",
                "Pulp Fiction",
                "The Lord of the Rings: The Fellowship of the Ring",
                "Forrest Gump",
                "Fight Club",
                "Inception",
                "The Lord of the Rings: The Two Towers",
                "Star Wars: Episode V - The Empire Strikes Back",
                "The Matrix",
                "Goodfellas",
                "One Flew Over the Cuckoo's Nest",
                "Se7en",
                "The Silence of the Lambs",
                "It's a Wonderful Life",
                "Star Wars: Episode IV - A New Hope",
                "Saving Private Ryan",
                "Spirited Away",
                "The Green Mile",
                "Life Is Beautiful",
                "Interstellar",
                "Parasite",
                "Léon: The Professional",
                "The Usual Suspects"
            };

            return titles[_random.Next(titles.Count)];
        }

        private string GetPart()
        {
            var parts = new List<string>
            {
                "I",
                "II",
                "III",
                "IV",
                "V",
                "VI",
                "VII",
                "VIII"
            };

            return parts[_random.Next(parts.Count)];
        }

        private string GetRandomDirector()
        {
            var directors = new List<string>
            {
                "Frank Darabont",
                "Francis Ford Coppola",
                "Christopher Nolan",
                "Martin Scorsese",
                "Sidney Lumet",
                "Steven Spielberg",
                "Peter Jackson",
                "Quentin Tarantino",
                "David Fincher",
                "Stanley Kubrick",
                "Robert Zemeckis",
                "James Cameron",
                "Ridley Scott",
                "George Lucas",
                "Joel Coen",
                "Ethan Coen",
                "Alfred Hitchcock",
                "Billy Wilder",
                "Orson Welles",
                "Charles Chaplin"
            };

            return directors[_random.Next(directors.Count)];
        }

        private int GetRandomReleaseYear(int low, int high)
        {
            return _random.Next(low, high);
        }

        private int GetRandomReleaseYear()
        {
            return _random.Next(1900, 2022);
        }

        private int GetRandomRating()
        {
            return (int) Math.Round(_random.NextDouble() * 10, 1);
        }

        private int GetRandomRating(int low, int high)
        {
            return low + (int) Math.Round(_random.NextDouble() * (high - low), 1);
        }

        private string GetRandomGenre()
        {
            var genres = new List<string>
            {
                "Action",
                "Adventure",
                "Animation",
                "Biography",
                "Comedy",
                "Crime",
                "Documentary",
                "Drama",
                "Family",
                "Fantasy",
                "Film Noir",
                "History",
                "Horror",
                "Music",
                "Musical",
                "Mystery",
                "Romance",
                "Sci-Fi",
                "Short Film",
                "Sport",
                "Superhero",
                "Thriller",
                "War",
                "Western"
            };

            return genres[_random.Next(genres.Count)];
        }

        private List<Actor> GetRandomActors(int count){
            var list = new List<Actor>();
            for(var i = 0; i < count; i++){
                var actor = new Actor()
                {
                    Name = GetRandomName(),
                    Age = GetRandomAge(),
                    Rating = GetRandomRating()
                };
                list.Add(actor);
            }
            return list;
        }

        private List<Actor> GetRandomActors(int count, List<string> names){
            var list = new List<Actor>();
            for( var name = 0; name < names.Count; name++){
                var actor = new Actor()
                {
                    Name = names[name],
                    Age = GetRandomAge(),
                    Rating = GetRandomRating()
                };
                list.Add(actor);
            }
            for(var i = names.Count; i < count; i++){
                var actor = new Actor()
                {
                    Name = GetRandomName(),
                    Age = GetRandomAge(),
                    Rating = GetRandomRating()
                };
                list.Add(actor);
            }
            return list;
        }

        private int GetRandomAge()
        {
            return _random.Next(18, 80);
        }

        private string GetRandomName(){
            var surnames = new List<string>
            {
                "Smith",
                "Johnson",
                "Williams",
                "Brown",
                "Jones",
                "Garcia",
                "Miller",
                "Davis",
                "Rodriguez",
                "Martinez",
                "Hernandez",
                "Lopez",
                "Gonzalez",
                "Wilson",
                "Anderson",
                "Thomas",
                "Taylor",
                "Moore",
                "Jackson",
                "Martin",
                "Lee",
                "Perez",
                "Thompson",
                "White",
                "Harris",
                "Sanchez",
                "Clark",
                "Ramirez",
                "Lewis",
                "Robinson",
                "Walker",
                "Young",
                "Allen"
            };

            var names = new List<string>
            {
                "James",
                "John",
                "Robert",
                "Michael",
                "William",
                "David",
                "Richard",
                "Josephine",
                "Thomas",
                "Charles",
                "Christopher",
                "Daniel",
                "Matthew",
                "Mary",
                "Patricia",
                "Linda",
                "Barbara",
                "Elizabeth",
                "Jennifer",
                "Maria",
                "Susan",
                "Margaret",
                "Dorothy",
                "Lisa",
                "Nancy",
                "Karen",
                "Betty",
                "Helen",
                "Sandra",
                "Donna",
                "Carol",
                "Ruth"
            };
            return names[_random.Next(names.Count)] + " " + surnames[_random.Next(surnames.Count)];
        }
    }
}
