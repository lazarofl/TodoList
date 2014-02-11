using System;
using NUnit.Framework;
using Castle.ActiveRecord;
using Todo.Web.Controllers;
using System.Web.Mvc;

namespace Todo.Test
{
    [TestFixture]
    public class TodoListTests : ActiveRecordTestBase
    {

        [Test]
        public void AddTodoTest()
        {
            HomeController controller = new HomeController();
            controller.Add("new todo");

            var expected = 1;
            var result = Todo.Model.Todo.FindAll().Length;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void AddTodoHaveJsonResultTest()
        {
            HomeController controller = new HomeController();
            var result = controller.Add("new todo");

            Assert.IsInstanceOf<JsonResult>(result);
        }

        [Test]
        public void NewTodoIsDoneFalseTest()
        {
            HomeController controller = new HomeController();
            controller.Add("new todo");
            var todo = Todo.Model.Todo.Find(1);

            var expected = false;

            Assert.AreEqual(expected, todo.Done);
        }

        [Test]
        public void ChangeTodoDoneToTrueTest()
        {
            HomeController controller = new HomeController();
            controller.Add("new todo");
            var todo = Todo.Model.Todo.Find(1);

            controller.Done(todo.Id, true);

            var expected = true;

            Assert.AreEqual(expected, todo.Done);
        }

    }
}
