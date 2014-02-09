using System;
using System.Web.Mvc;

namespace Todo.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var todolist = Todo.Model.Todo.FindAll();
            return Json(todolist, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string name)
        {
            var todo = new Todo.Model.Todo();
            todo.Name = name;
            todo.Done = false;

            todo.SaveAndFlush();

            return Json(todo, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult Done(string id, bool done)
        {
            var todo = Todo.Model.Todo.Find(int.Parse(id));
            todo.Done = done;

            todo.SaveAndFlush();

            return Json(todo, JsonRequestBehavior.AllowGet);
        }

    }
}
