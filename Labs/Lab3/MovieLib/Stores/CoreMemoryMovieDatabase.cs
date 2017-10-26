using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Stores
{
    public class CoreMemoryMovieDatabase : MovieDatabase
    {
        /// <summary>Adds a movie.</summary>
        /// <param name="movie"></param>
        /// <returns>The added movie.</returns>
        public Movie AddCore (Movie movie)
        {
            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            if (newMovie.Id <= 0)
                newMovie.Id = _nextId++;
            else if (newMovie.Id >= _nextId)
                _nextId = newMovie.Id + 1;

            return CopyMovie(newMovie);
        }

        /// <summary>Gets a specific movie.</summary>
        /// <param name="id"></param>
        /// <returns>The movie if it exists.</returns>
        public Movie GetCore(int id)
        {
            var movie = FindMovie(id);

            return (movie != null) ? CopyMovie(movie) : null;
        }

        /// <summary>Get all movies.</summary>
        /// <returns>All the movies.</returns>
        public IEnumerable<Movie> GetAllCore()
        {
            foreach (var movie in _movies)
                yield return CopyMovie(movie);
        }

        /// <summary>Removes a movie.</summary>
        /// <param name="id"></param>
        public void RemoveCore (int id)
        {
            var movie = FindMovie(id);
            if (movie != null)
                _movies.Remove(movie);
        }

        /// <summary>Updates a movie.</summary>
        /// <param name="existing"></param>
        /// <param name="movie"></param>
        /// <returns>The updated movie.</returns>
        public Movie UpdateCore (Movie existing, Movie movie)
        {
            //Replace
            existing = FindMovie(movie.Id);
            _movies.Remove(existing);
            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            return CopyMovie(newMovie);
        }

        /// <summaryFind a movie by id.</summary>
        /// <param name="id"></param>
        /// <returns>The movie if it exists.</returns>
        private Movie FindMovie(int id)
        {
            foreach(var movie in _movies)
            {
                if (movie.Id == id)
                    return movie;
            };

            return null;
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
                Duration = movie.Duration,
                Owned = movie.Owned
            };

            return newMovie;
        }

        private List<Movie> _movies = new List<Movie>();
        private int _nextId = 1;
    }
}
