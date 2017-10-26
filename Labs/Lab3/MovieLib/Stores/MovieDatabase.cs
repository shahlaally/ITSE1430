using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Stores
{
    /// <summary>Base class for movie database.</summary>
    public class MovieDatabase //: IMovieDatabase
    {
        /// <summary>Adds a movie.</summary>
        public Movie Add ( Movie movie )
        {
            //TODO: Validate
            if (movie == null)
                return null;

            //Using IValidatableObject
            if (!ObjectValidator.TryValidate( movie, out var errors))
                return null;

            //Emulate database by storing copy
            return AddCore(movie);
        }

        /// <summary>Get a specific movie.</summary>
        /// <param name="id"></param>
        /// <returns>The movie if it exists.</returns>
        public Movie Get ( int id )
        {
            //TODO Validate
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        /// <summary>Gets all movies.</summary>
        /// <returns>All the movies.</returns>
        public IEnumerable<Movie> GetAll ()
        {
            return GetAllCore();
        }

        public void Remove ( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return;

            RemoveCore(id);
        }

        /// <summary>Updates a Movie.</summary>
        /// <param name="movie"></param>
        /// <returns>The updated movie.</returns>
        public Movie Update ( Movie movie)
        {
            //TODO: Validate
            if (movie == null)
                return null;

            //Using IValidatableObject
            if (!ObjectValidator.TryValidate(movie, out var errors))
                return null;
            //Get existing movie
            var existing = GetCore(movie.Id);
            if (existing == null)
                return null;

            return UpdateCore(existing, movie);
        }
    }
}
