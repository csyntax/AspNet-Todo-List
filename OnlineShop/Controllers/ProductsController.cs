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
using OnlineShop.Infrastructure.Mapping;
using System.Linq;
using System.Web.Mvc;

using OnlineShop.ViewModels.Products;

using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace OnlineShop.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

       /* public ProductsController(ApplicationDbContext db)
        {
            this.db = db;
        }*/
        // GET: Products
        public ActionResult Index()
        {

            var currentUserName = this.User.Identity.Name;
            var viewModel = db.Products.Where(x => x.User.UserName == currentUserName).Project().To<ProductViewModel>().ToList();

            return this.View(viewModel);
        }
       
        public ActionResult Add(ProductViewModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var currentUserName = this.User.Identity.Name;
                var user = this.db.Users.FirstOrDefault(x => x.UserName == currentUserName);

                var newProduct = new Product {
                    Name= inputModel.Name,
                    User = user
                };

                this.db.Products.Add(newProduct);
                this.db.SaveChanges();

            }

            return this.RedirectToAction("Index");
        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
