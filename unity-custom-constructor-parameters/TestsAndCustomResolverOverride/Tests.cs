using TestSubject;
using Microsoft.Practices.Unity;
using NUnit.Framework;

namespace ClassLibrary2
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestParameterOverride()
        {
            var unity = new UnityContainer();
            unity.RegisterType<MyClass>();

            var myObj = unity.Resolve<MyClass>(new ResolverOverride[]
                                           {
                                               new ParameterOverride("hello", "hi there"), new ParameterOverride("number", 21)
                                           });

            Assert.That(myObj.Hello, Is.EqualTo("hi there"));
            Assert.That(myObj.Number, Is.EqualTo(21));
        }

        [Test]
        public void TestOrderedParametersOverride()
        {
            var unity = new UnityContainer();
            unity.RegisterType<MyClass>();

            var myObj = unity.Resolve<MyClass>(new OrderedParametersOverride(new object[] {"greetings", 24 }));

            Assert.That(myObj.Hello, Is.EqualTo("greetings"));
            Assert.That(myObj.Number, Is.EqualTo(24));
        }
    }
}
