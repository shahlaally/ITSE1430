using System.Collections.Generic;

namespace MovieLib
{
    /// <summary>Provides a database of movies.</summary>
    public interface IMovieDatabase
    {
        /// <summary>Adds a movie.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The added movie</returns>
        Movie Add( Movie movie );

        /// <summary>Gets all movies.</summary>
        /// <returns>All the movies.</returns>
        IEnumerable<Movie> GetAllCore();

        /// <summary>Get a specific movie.</summary>
        /// <param name="id"></param>
        /// <returns>The product if it exists.</returns>
        Movie Get( int id );

        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        void Remove( int id );

        /// <summary>Updates a movie.</summary>
        /// <param name="existing"></param>
        /// <param name="movie">The movie to update.</param>
        /// <returns>The updated movie.</returns>
        Movie Update( Movie existing, Movie movie );
    }
}