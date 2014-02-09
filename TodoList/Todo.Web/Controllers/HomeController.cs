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

        public ActionResult GetAll()
        {
            throw new NotImplementedException();
        }

        public ActionResult Add(string name)
        {
            throw new NotImplementedException();
        }

        public ActionResult Toggle(string id)
        {
            throw new NotImplementedException();
        }

    }
}
