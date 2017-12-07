using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        private readonly string _connectionString;

        public SqlProductDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override Product AddCore(Product product)
        {
            var id = 0;
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("AddProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                id = Convert.ToInt32(cmd.ExecuteScalar());
            };
            return GetCore(id);
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            var products = new List<Product>();
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("GetAllProducts", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product()
                        {
                            Id = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Price = Convert.ToDecimal(reader["Price"]),
                            Description = reader["Description"].ToString(),
                            IsDiscontinued = Convert.ToBoolean(reader["IsDiscontinued"])
                        };
                        products.Add(product);
                    }
                };
            };
            return products;
        }

        protected override Product GetCore( int id )
        {
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("GetProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                var ds = new DataSet();
                var da = new SqlDataAdapter()
                {
                    SelectCommand = cmd
                };

                da.Fill(ds);
                var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
                if (table != null)
                {
                    var row = table.AsEnumerable().FirstOrDefault();
                    if (row != null)
                    {
                        return new Product()
                        {
                            Id = Convert.ToInt32(row["id"]),
                            Name = row.Field<string>("Name"),
                            Description = row.Field<String>("Description"),
                            Price = row.Field<decimal>("price"),
                            IsDiscontinued = row.Field<bool>("isDiscontinued")
                        };
                    }
                }

                return new Product();
            };
        }

        protected override void RemoveCore( int id )
        {
            using (var conn = OpenDatabase())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveProduct";
                cmd.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("@Id", id);
                cmd.Parameters.Add(parameter);

                cmd.ExecuteNonQuery();
            }
        }

        protected override Product UpdateCore( Product existing, Product product )
        {
            var id = 0;
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("UpdateProduct", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                cmd.ExecuteNonQuery();
            };
            return GetCore(existing.Id);
        }

        private SqlConnection OpenDatabase()
        {
            var connection = new SqlConnection(_connectionStriong);
            connection.Open();
            return connection;
        }
    }
}
