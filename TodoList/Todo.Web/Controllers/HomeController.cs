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
            var todolist = Todo.Model.Todo.FindAll(new NHibernate.Criterion.Order("Id",false));
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
        public void Done(int id, bool done)
        {
            var todo = Todo.Model.Todo.Find(id);
            todo.Done = done;

            todo.SaveAndFlush();
        }


    }
}
