using ComplexJsonNestedSerialization.Core.Models;
using ComplexJsonNestedSerialization.Core.Services;
using NUnit.Framework;
using System.Linq;

namespace ComplexJsonNestedSerialization.Core.Tests
{
    [TestFixture]
    public class TestFooTests
    {
        private const int _numberOfBars = 2;
        private const int _numberOfBazes = 4;

        [Test]
        public void CheckAssumptionsTestFooDefault()
        {
            var data = TestFoo.GetDefaultFoo();

            Assert.AreEqual(_numberOfBars, data.Bars.Count(), nameof(_numberOfBars));
            Assert.AreEqual(_numberOfBazes, data.Bars.Sum(c => c.Bazes.Count()), nameof(_numberOfBazes));
        }

        [Test]
        public void ShouldContainCorrectNumberOfNestedObjects()
        {
            const int numberOfBars = 2;
            const int numberOfBazes = 4;

            var json = new FooSerializer().Serialize(TestFoo.GetDefaultFoo());
            FooDeserializer<Foo> fd = new FooDeserializer<Foo>();

            var result = fd.Deserialize(json);

            Assert.AreEqual(numberOfBars, result.Bars.Count(), nameof(numberOfBars));
            Assert.AreEqual(numberOfBazes, result.Bars.Sum(c => c.Bazes.Count()), nameof(numberOfBazes));
        }
    }
}
