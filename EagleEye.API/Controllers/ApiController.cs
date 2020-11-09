using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EagleEye.API.DataAccess;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EagleEye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IMovieAPI _Movies;
        public ApiController(IMovieAPI Movies)
        {
            _Movies = Movies;
        }

        // GET: api/<ApiController>
        [HttpGet]
        public List<Movie> GetMovies()
        {
            var test = _Movies.GetAllMovies();
            return test;
        }

        // POST api/<ApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
