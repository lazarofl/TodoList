using System;
using NUnit.Framework;
using Castle.ActiveRecord;

namespace Todo.Test
{
    [TestFixture]
    public class TodoListTests : ActiveRecordTestBase
    {
       
        [Test]
        public void AdicionarTodoTeste()
        {
            Todo.Model.Todo todo = new Model.Todo();
            todo.Name = "Nova todo";
            todo.Save();

            var expected = 1;

            var result = Todo.Model.Todo.FindAll().Length;

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void MarcarComoFinalizadoTeste()
        {

        }

        [Test]
        public void ObterTodasAsTodosTeste()
        {

        }


    }
}
