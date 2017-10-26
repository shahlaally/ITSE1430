using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Stores
{
    public class InMemoryMovieDatabase : CoreMemoryMovieDatabase
    {
        public InMemoryMovieDatabase()  
        {
            #region Other approaches
            //Long way
            //var movie = new Movie();
            //movie.Title = "Samsung Note 7";
            //movie.Duration = 150;
            //movie.IsOwned = true;
            //Add(movie);

            //Object initializer syntax
            //_movies.Add(new Movie() { Id = 1, Title = "Galaxy S7", Duration = 650 });
            //_movies.Add(new Movie() { Id = 2, Title = "Galaxy Note 7", Duration = 150, IsOwnrd = true });
            //_movies.Add(new Movie() { Id = 3, Title = "Windows Phone", Duration = 100 });
            //_movies.Add(new Movie() { Id = 4, Title = "iPhone X", Price = 1900, IsOwned = true });

            //Collection initializer syntax
            //_movies = new List<Movie>() { 
            //    new Movie() { Id = 1, Title = "Galaxy S7", Duration = 650 },
            //    new Movie() { Id = 2, Title = "Galaxy Note 7", Duration = 150, IsOwnrd = true },
            //    new Movie() { Id = 3, Title = "Windows Phone", Duration = 100 },
            //    new Movie() { Id = 4, Title = "iPhone X", Duration = 1900, IsOwned = true },
            //};
            #endregion

            //Collection initializer syntax with array
            //_movies.AddRange(new [] {            
            AddCore(new Movie() { Id = 1, Title = "Galaxy S7", Duration = 650 });
            AddCore(new Movie() { Id = 2, Title = "Galaxy Note 7", Duration = 150, IsOwned = true });
            AddCore(new Movie() { Id = 3, Title = "Windows Phone", Duration = 100 });
            AddCore(new Movie() { Id = 4, Title = "iPhone X", Duration = 1900, IsOwned = true });
            //});            

            //_nextId = _products.Count + 1;
        }
    }
}
