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
            var viewModel = db.TodoItems.Where(u => u.User.UserName == currentUserName).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TodoItem todoItem)
        {
            if (ModelState.IsValid)
            {
                var currentUserName = User.Identity.Name;
                var user = db.Users.FirstOrDefault(u => u.UserName == currentUserName);
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
            var todo = db.TodoItems.FirstOrDefault(todoItem => todoItem.Id == id);

            db.TodoItems.Remove(todo);

            db.SaveChanges(); 

            return RedirectToAction("Index");
        }
    }
}