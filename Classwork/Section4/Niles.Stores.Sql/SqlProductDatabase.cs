﻿using System;
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
        
        protected override Product AddCore( Product product )
        {
            throw new NotImplementedException();
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
                    var product = new Product() 
                    {
                        Id = reader.IsDBNull(0) ? 0 : Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"]),
                        Description = reader["Description"].ToString(),
                        IsDiscontinued = Convert.ToBoolean(reader["IsDiscontinued"])
                    };
                    products.Add(product);                  
                };
            };
            return products;
        }

        protected override Product GetCore( int id )
        {
            throw new NotImplementedException();
        }

        protected override void RemoveCore( int id )
        {
            throw new NotImplementedException();
        }

        protected override Product UpdateCore( Product existing, Product newItem )
        {
            throw new NotImplementedException();
        }

        private SqlConnection OpenDatabase()
        {
            var connection = new SqlConnection();
            connection.Open();
            return connection;
        }
    }
}
