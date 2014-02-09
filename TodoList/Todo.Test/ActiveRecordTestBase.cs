using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord.Framework.Config;
using NUnit.Framework;
using System.Reflection;

namespace Todo.Test
{
    public abstract class ActiveRecordTestBase
    {
        protected SessionScope scope;

        [TestFixtureSetUp]
        public void InitialiseAR()
        {
            ActiveRecordStarter.ResetInitializationFlag();
            IConfigurationSource source = new
              XmlConfigurationSource("ActiveRecordConfig.xml");
            ActiveRecordStarter.Initialize(
               Assembly.GetAssembly(typeof(Todo.Model.Todo)),
              source);
        }

        [SetUp]
        public virtual void SetUp()
        {
            ActiveRecordStarter.DropSchema();
            ActiveRecordStarter.CreateSchema();
            scope = new SessionScope();
        }

        [TearDown]
        public virtual void TearDown()
        {
            scope.Dispose();
        }

        public void Flush()
        {
            scope.Flush();
            scope.Dispose();
            scope = new SessionScope();
        }

    }
}
