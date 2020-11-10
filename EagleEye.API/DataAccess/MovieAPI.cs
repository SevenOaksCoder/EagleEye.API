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
            return File.ReadAllLines(METADATA_URL)
                .Skip(1) // skip field names
                .Select(v => MapMovies(v))
                .ToList();
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
            movie.ReleaseYear = Convert.ToDateTime(values[5]).Year;

            return movie;
        }
    
        public Movie GetMovieById(int MovieId)
        {
            var movie = new Movie();

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
    }
}
