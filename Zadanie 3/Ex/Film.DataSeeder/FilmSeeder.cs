using System;
using System.Collections.Generic;
using Film.Shared.Model;

namespace Film.DataSeeder
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
                    ReleaseYear = GetRandomReleaseYear(),
                    Rating = GetRandomRating()
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

        private int GetRandomReleaseYear()
        {
            return _random.Next(1900, 2022);
        }

        private double GetRandomRating()
        {
            return Math.Round(_random.NextDouble() * 10, 1);
        }
    }
}
