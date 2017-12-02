using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nile.Web.Models
{
    /// <summary>Provides extension methods for <see cref="Product"/>./></summary>
    public static class ProductExtension
    {
        /// <summary>Converts a <see cref="Product"/> to a <see cref="ProductViewModel"/>./></summary>
        /// <param name="source" is the Product.></param>
        /// <returns>The model.</returns>
        public static ProductViewModel ToModel (this Product source)
        {
            return new ProductViewModel()
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                IsDiscontinued = source.IsDiscontinued
            };
        }

        /// <summary>Converts a <see cref="ProductViewModel"/> to a <see cref="Product"./></summary>
        /// <param name="source">is the ProductViewModel</param>
        /// <returns>The Product.</returns>
        public static Product ToDomain(this ProductViewModel source)
        {
            return new Product()
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                IsDiscontinued = source.IsDiscontinued
            };
        }

        /// <summary>Converts a <see cref="Product"/> to a <see cref="ProductViewModel"/></summary>
        /// <param name="source">The product</param>
        /// <returns>The model</returns>
        public static IEnumerable<ProductViewModel> ToModel(this IEnumerable<Product> source)
        {
            foreach (var item in source)
                yield return item.ToModel();
            //return from item in source
                   //select item.ToModel();
            
        }
    }
}