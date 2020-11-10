using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EagleEye.API.DataAccess
{
    public class MovieAPI : IMovieAPI
    {
        private const string METADATA_URL = @"C:\Users\User\source\repos\EagleEye.API\EagleEye.API\DataAccess\metadata.csv";
        private const string STATSDATA_URL = @"C:\Users\User\source\repos\EagleEye.API\EagleEye.API\DataAccess\stats.csv";
        public List<Movie> GetAllMovies()
        {
            var movies = ReadCsv();
            return movies;
        }

        private Movie MapMovies(string row)
        {
            string[] values = row.Split(',');
            var movie = new Movie();

            movie.Id = Convert.ToInt32(values[0]);
            movie.MovieId = Convert.ToInt32(values[1]);
            movie.Title = values[2];
            movie.Language = values[3];
            movie.Duration = values[4];
            movie.ReleaseYear = values[5];

            return movie;
        }
    
        public Movie GetMovieById(int movieId)
        {
            var movies = ReadCsv();
            var movie = new Movie();
            foreach (var film in movies)
            {
                if(film.MovieId == movieId)
                {
                    if (film.Id > movie.Id)
                    {
                        movie.Id = film.Id;
                        movie.MovieId = film.MovieId;
                        movie.Title = film.Title;
                        movie.Language = film.Language;
                        movie.Duration = film.Duration;
                        movie.ReleaseYear = film.ReleaseYear;
                    }
                }
            }

            return movie;
        }

        [HttpPost]
        public void NewMovie(Movie movie)
        {
            string fileName = METADATA_URL;
            string row = $"{movie.Id},{movie.MovieId},{movie.Title},{movie.Language},{movie.Duration},{movie.ReleaseYear}";

            if (File.Exists(fileName))
            {
                File.AppendAllText(fileName, row);
            }
        }

        private List<Movie> ReadCsv()
        {
            return File.ReadAllLines(METADATA_URL)
                .Skip(1) // skip field names
                .Select(v => MapMovies(v))
                .ToList();
        }
    }
}
