using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiTutorial.Models;

using System.Data.Entity;
namespace ApiTutorial.Controllers
{
    public class ProductController : ApiController
    {
        private ProductContext db = new ProductContext();
        // Get all product
        [HttpGet()]
        public IHttpActionResult Get()
        {
            IHttpActionResult ret = null;
            List<Product> list = new List<Product>();
            list = db.Products.ToList();
            if (list.Count > 0)
            {
                ret = Ok(list);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        // Get Sigle Product
        [HttpGet()]
        public IHttpActionResult Get(int id)
        {
            IHttpActionResult ret;
            Product prod = new Product();
            //List<Product> list = new List<Product>();
            // list = db.Products.ToList();

            prod = db.Products.Where(p => p.ProductId == id).First();
            if (prod == null)
            {
                ret = NotFound();
            }
            else
            {
                ret = Ok(prod);
            }

            return ret;
        }

        // Add new product
        [HttpPost()]
        public IHttpActionResult Post(Product product)
        {
            IHttpActionResult ret = null;

            product = db.Products.Add(product);
            db.SaveChanges();

            if (product != null)
            {
                ret = Created<Product>(Request.RequestUri +
                     product.ProductId.ToString(), product);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        // Update product
        [HttpPut()]
        public IHttpActionResult Put(int id, Product product)
        {
            IHttpActionResult ret = null;

            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            if (product != null)
            {
                ret = Ok(product);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        // Delete product
        [HttpDelete()]
        public IHttpActionResult Delete(int id)
        {
            IHttpActionResult ret = null;
            Product product = new Product();

            product = db.Products.Where(p => p.ProductId == id).First();
            db.Products.Remove(product);
            db.SaveChanges();

            if (product != null)
            {
                ret = Ok(true);
            }
            else
            {
                ret = NotFound();
            }
            return ret;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}