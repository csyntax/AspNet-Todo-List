using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;

using OnlineShop.ViewModels.Products;

using AutoMapper.QueryableExtensions;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var currentUserName = this.User.Identity.Name;
            var viewModel = db.Products
                            .Where(x => x.User.UserName == currentUserName)
                            .Project().
                            To<ProductViewModel>()
                            .ToList();

            return this.View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult Add(ProductViewModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var currentUserName = this.User.Identity.Name;
                var user = this.db.Users.FirstOrDefault(x => x.UserName == currentUserName);

                var newProduct = new Product {
                    User = user,
                    Name = inputModel.Name,
                    Description = inputModel.Description,
                    Category = inputModel.Category,
                    Price = inputModel.Price,
                    Published = inputModel.Published
                };

                this.db.Products.Add(newProduct);
                this.db.SaveChanges();

            }

            return this.RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
