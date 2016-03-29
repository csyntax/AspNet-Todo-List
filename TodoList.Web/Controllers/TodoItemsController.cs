using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;
using TodoList.Data;

namespace TodoList.Web.Controllers
{
    [Authorize]
    public class TodoItemsController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var currentUserName = User.Identity.Name;
            var viewModel = db.TodoItems.Where(x => x.User.UserName == currentUserName).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                var currentUserName = User.Identity.Name;
                var user = db.Users.FirstOrDefault(x => x.UserName == currentUserName);
                var todo = new TodoItem {
                    Title = todoItem.Title,
                    User = user
                };

                db.TodoItems.Add(todo);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var todo = db.TodoItems.FirstOrDefault(user => user.Id == id);

            db.TodoItems.Remove(todo);

            db.SaveChanges(); 

            return RedirectToAction("Index");
        }
    }
}