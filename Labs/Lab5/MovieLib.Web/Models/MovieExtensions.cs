using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieLib.Web.Models
{
    public static class MovieExtensions
    {
        public static MovieViewModel ToModel (this Movie source)
        {
            return new MovieViewModel()
            {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                Duration = source.Duration,
                IsOwned = source.IsOwned
            };
        }

        public static Movie ToDomain (this MovieViewModel source)
        {
            return new Movie()
            {
                Id = source.Id,
                Title = source.Title,
                Description = source.Description,
                Duration = source.Duration,
                IsOwned = source.IsOwned
            };
        }

        public static IEnumerable<MovieViewModel> ToModel (this IEnumerable<Movie> source)
        {
            foreach (var item in source)
                yield return item.ToModel();
        }

    }
}