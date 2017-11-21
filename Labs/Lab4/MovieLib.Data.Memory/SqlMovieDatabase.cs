using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Data.Memory
{
    /// <summary>provides Implementation of methods accessing Sql Serverdatabase</summary>
    public class SqlMovieDatabase : IMovieDatabase
    {
        public SqlMovieDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        /// <summary>Adds a movie. </summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The added movie.</returns>
        public Movie Add( Movie movie )
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
        public Movie AddCore(Movie movie)
        {
            var id = 0;
            using (var conn = OpenDatabase())
            {
                var cmd = new SqlCommand("AddMovie", conn)
                { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = movie.Title;
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@duration", movie.Duration);
                cmd.Parameters.AddWithValue("@isOwned", movie.IsOwned);

                id = Convert.ToInt32(cmd.ExecuteScalar());
            };

            return Get(id);
        }

        /// <summary>Get a specific movie.</summary>
        /// <param name="id">The movie to get.</param>
        /// <returns>The movie if it exists.</returns>
        public Movie Get( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        /// <summary>Get a specific movie.</summary>
        /// <param name="id">The movie to get.</param>
        /// <returns>The movie, if it exists.</returns>
        public Movie GetCore(int id)
        {
            using (var conn = OpenDatabase())
            {
                var cmd = new SqlCommand("GetMovie", conn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);

                //Using a dataset instead of a reader
                var ds = new DataSet();
                var da = new SqlDataAdapter()
                {
                    SelectCommand = cmd,
                };

                da.Fill(ds);

                var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
                if (table != null)
                {
                    var row = table.AsEnumerable().FirstOrDefault();
                    if (row != null)
                    {
                        return new Movie()
                        {
                            Id = Convert.ToInt32(row["Id"]),
                            Title = row.Field<string>("Title"),
                            Description = row.Field<string>("Description"),
                            Duration = row.Field<int>("Length"),
                            IsOwned = row.Field<bool>("IsOwned")
                        };
                    };
                };
            };

            return null;
        }

        /// <summary>Gets all movies.</summary>
        /// <returns>All the movies.</returns>
        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

        /// <summary>Gets all movies.</summary>
        /// <returns>All the movies.</returns>
        public IEnumerable<Movie> GetAllCore()
        {
            var products = new List<Movie>();
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("GetAllMovies", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Movie()
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Title = reader.GetFieldValue<string>(1),                         
                            Description = reader.GetString(2),
                            Duration = reader.GetInt32(3),
                            IsOwned = reader.GetBoolean(4)
                        };
                        products.Add(product);
                    };
                };

                return products;
            };
        }

        /// <summary>Removes the movie.</summary>
        /// <param name="id">The movie to remove.</param>
        public void Remove( int id )
        {
            //TODO: Validate
            if (id <= 0)
                return;

            RemoveCore(id);
        }

        /// <summary>Removes the movie.</summary>
        /// <param name="id">The movie to remove.</param>
        public void RemoveCore(int id)
        {
            using (var conn = OpenDatabase())
            {
                //Alternative approach to creating command
                var cmd = conn.CreateCommand();
                //cmd.CommandText = "DELETE FROM Movies WHERE Id = @id";
                cmd.CommandText = "RemoveMovie";
                cmd.CommandType = CommandType.StoredProcedure;

                //Long way
                var parameter = new SqlParameter("@id", id);
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();
            };
        }

        /// <summary>Updates a movie.</summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>The updated movie.</returns>
        public Movie Update( Movie movie )
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

        private SqlConnection OpenDatabase()
        {
            var connection = new SqlConnection(_connectionString);

            connection.Open();

            return connection;
        }

        /// <summary>Updates a movie.</summary>
        /// <param name="existing">The movie to remove.</param>
        /// <param name="movie">The movie to replace.</param>
        /// <returns>The updated movie.</returns>
        public Movie UpdateCore (Movie existing, Movie movie)
        {
            using (var conn = OpenDatabase())
            {
                var cmd = new SqlCommand("UpdateMovie", conn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@id", existing.Id);
                cmd.Parameters.AddWithValue("@name", movie.Title);
                cmd.Parameters.AddWithValue("@description", movie.Description);
                cmd.Parameters.AddWithValue("@price", movie.Duration);
                cmd.Parameters.AddWithValue("@isDiscontinued", movie.IsOwned);

                cmd.ExecuteNonQuery();
            };

            return Get(movie.Id);
        }
    }
}
