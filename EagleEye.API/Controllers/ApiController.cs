using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EagleEye.API.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EagleEye.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IMovieAPI _Movies;
        public ApiController(IMovieAPI Movies)
        {
            _Movies = Movies;
        }

        [HttpGet("getmovies")]
        public List<Movie> GetMovies()
        {
            var movies = _Movies.GetAllMovies();
            return movies;
        }

        [HttpGet("getmovie/{id}")]
        public Movie GetMovie(int id)
        {
            var movie = _Movies.GetMovieById(id);
            return movie;
        }

        [HttpPost("postmovie")]
        public void PostMovie([FromBody] Movie movie)
        {
            _Movies.NewMovie(movie);
        }
    }
}
