using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    /// <summary>Base class for product database</summary>
    public class ProductDatabase
    {
        public ProductDatabase()
        {
            _products[0] = new Product();
            _products[0].Name = "Galaxy";
            _products[0].Price = 650;

            _products[1] = new Product();
            _products[1].Name = "Samsung Note 7";
            _products[1].Price = 150;
            _products[1].IsDiscontinued = true;

            _products[1] = new Product();
            _products[1].Name = "Samsung Note 7";
            _products[1].Price = 150;
            _products[1].IsDiscontinued = true;
        }
        /// <summary>Adds a product</summary>
        /// <param name="product"></param>
        public void Add (Product product)
        {
            //TODO: Implement Add
        }

        /// <summary>Get a specic product</summary>
        /// <returns></returns>
        public Product Get()
        {
            //TODO: Implement Get
        }

        public Product Update (Product product)
        {
            //TODO: Implement Update
        }

        /// <summary>removes a product</summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public void Remove (Product product)
        {
            //TODO: Implement Remove
        }

        public Product[] GetAll()
        {
            var items = new Product[_products.Length];
            var index = 0;
            foreach (var product in _products)
            {
                items[index] = CopyProduct(product);
            };
            return _products;
        }



        private Product[] _products = new Product[100];
    }
}
