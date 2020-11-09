using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EagleEye.API.DataAccess
{
    public interface IMovieAPI
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int MovieId);
        Movie NewMovie(Movie movie);
    }
}
