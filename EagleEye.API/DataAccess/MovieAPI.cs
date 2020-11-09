using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace EagleEye.API.DataAccess
{
    public class MovieAPI : IMovieAPI
    {
        public List<Movie> GetAllMovies()
        {
            return File.ReadAllLines($"/metadata.csv")
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
            movie.ReleaseYear = values[5];

            return movie;
        }
    
        public Movie GetMovieById(int MovieId)
        {
            var movie = new Movie();

            return movie;
        }

        [HttpPost]
        public Movie NewMovie(Movie movie)
        {
            

            return movie;
        }
    }
}
