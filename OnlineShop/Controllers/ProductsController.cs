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
            var viewModel = db.Products.Where(user => user.User.UserName == currentUserName).ProjectTo<ProductIndexViewModel>().ToList();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]       
        public ActionResult Add(ProductViewModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var currentUserName = this.User.Identity.Name;
                var user = this.db.Users.FirstOrDefault(x => x.UserName == currentUserName);

                this.db.Products.Add(new Product
                {
                    User = user,
                    Name = inputModel.Name,
                    Description = inputModel.Description,
                    Category = inputModel.Category,
                    Price = inputModel.Price,
                    Published = inputModel.Published
                });

                this.db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var product = db.Products.Where(x => x.Id == id).ProjectTo<ProductDetailsViewModel>().FirstOrDefault();

            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var product = db.Products.Find(id);

            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
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