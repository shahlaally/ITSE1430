using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nile.Web.Models;
using Nile.Stores.Sql;

namespace Nile.Web.Controllers
{
    public class ProductController : Controller
    {
        public ProductController () : this(GetDatabase())
        {

        }

        public ProductController (IProductDatabase database)
        {
            _database = database;
        }

        // GET: Product
        public ActionResult Add ()
        {
            var model = new List<ProductViewModel>() {
                new ProductViewModel() {Id = 1, Name = "Product A", Price = 123}
            };
            //var model = new ProductViewModel();

            return View(model);
        }

        public ActionResult Delete (int id)
        {
            var product = _database.Get(id);

            return View(product.ToModel());
        }

        public ActionResult Edit(int id)
        {
            var product = _database.Get(id);

            return View(product.ToModel());
        }

        public ActionResult List()
        {
            var products = _database.GetAll();

            return View(products.ToModel());
        }

        private static  IProductDatabase GetDatabase ()
        {
            var connstring = ConfigurationManager.ConnectionStrings["ProductDatabase"];

            return new SqlProductDatabase(connstring.ConnectionString);
        }

        

    private readonly IProductDatabase  _database;
    }
}