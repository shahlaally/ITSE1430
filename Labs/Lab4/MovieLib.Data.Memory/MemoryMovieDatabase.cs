using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Data.Memory
{
    public class MemoryMovieDatabase : IMovieDatabase
    {

        /// <summary>Get a specific movie.</summary>
        /// <param name="id">The movie to get.</param>
        /// <returns>The movie if it exists.</returns>
        public Movie Get(int id)
        {
            //TODO: Validate
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        /// <summary>Get a specific movie.</summary>
        /// <param name="id">The movie to get.</param>
        /// <returns>The movie, if it exists.</returns>
        private Movie GetCore (int id)
        {
            var movie = FindMovie(id);
            return (movie != null) ? CopyMovie(movie) : null;
             
        }

        /// <summary>Gets all movies.</summary>
        /// <returns>All the movies.</returns>
        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }


        /// <summary>Gets all movies.</summary>
        /// <returns>All the movies.</returns>
        private IEnumerable<Movie> GetAllCore ()
        {
            foreach (var movie in _movies)
                yield return CopyMovie(movie);
        }

        /// <summary>Removes the movie.</summary>
        /// <param name="id">The movie to remove.</param>
        public void Remove(int id)
        {
            //TODO: Validate
            if (id <= 0)
                return;

            RemoveCore(id);
        }


        /// <summary>Removes the movie.</summary>
        /// <param name="id">The movie to remove.</param>
        private void RemoveCore(int id)
        {
            var movie = FindMovie(id);
            if (movie != null)
                _movies.Remove(movie);
        }

        /// <summary>Adds a movie. </summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The added movie.</returns>
        public Movie Add(Movie movie)
        {
            //TODO: Validate
            if (movie == null)
                return null;

            //Using IValidatableObject
            if (!ObjectValidator.TryValidate(movie, out var errors))
                return null;

            return AddCore(movie);
        }

        /// <summary>Adds a movie.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The added movie.</returns>
        private Movie AddCore (Movie movie)
        {

            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            if (newMovie.Id <= 0)
                newMovie.Id = _nextid++;
            else if (newMovie.Id >= _nextid)
                _nextid = movie.Id + 1;

            return CopyMovie(newMovie);
        }

        /// <summary>Updates a movie.</summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>The updated movie.</returns>
        public Movie Update(Movie movie)
        {
            //TODO: Validate
            if (movie == null)
                return null;

            //Using IValidatableObject
            if (!ObjectValidator.TryValidate(movie, out var errors))
                return null;

            // Get existing movie
            var existing = GetCore(movie.Id);
            if (existing == null)
                return null;
            return UpdateCore(existing, movie);

        }

        /// <summary>Updates a movie.</summary>
        /// <param name="existing">The movie to remove.</param>
        /// <param name="movie">The movie to replace.</param>
        /// <returns>The updated movie.</returns>
        private Movie UpdateCore (Movie existing, Movie movie)
        {
            //Replace
            existing = FindMovie(movie.Id);
            _movies.Remove(existing);
            var newmovie = CopyMovie(movie);
            _movies.Add(newmovie);

            return CopyMovie(newmovie);
        }

        private Movie CopyMovie (Movie movie)
        {
            if (movie == null)
                return null;

            var newMovie = new Movie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                IsOwned = movie.IsOwned
            };

            return newMovie;
        }


        //Find a movie by ID
        private Movie FindMovie(int id)
        {
            foreach (var movie in _movies)
            {
                if (movie.Id == id)
                    return movie;
            };

            return null;
        }

        private List<Movie> _movies = new List<Movie>();
        private int _nextid = 1;
    }
}
