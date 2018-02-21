using NUnit.Framework;
using System;
using ComplexJsonNestedSerialization.Core.JsonConverters;
using ComplexJsonNestedSerialization.Core.Models;
using ComplexJsonNestedSerialization.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Tests
{
    [TestFixture]
    public class FooSerializerTests
    {

        private FooSerializer<Bar, Baz> _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new FooSerializer<Bar, Baz>();
        }

        private static object[] _testData = new object[]
        {
            new object[]
            {
                new BazConverterServer<Baz>(),
                4
            },
            new object[]
            {
                new BazConverterClient(),
                3
            }
        };

        [Test]
        [TestCaseSource(nameof(_testData))]
        public void ShouldExcludeRakatakaMyPropertyWithClientProjection(BazConverterBase<Baz> converterType, int myPropertyNumberOccurences)
        {
            _subject.JsonConverters = new List<JsonConverter>()
            {
                converterType
            };

            var json = _subject.Serialize(TestFoo.GetDefaultFoo());

            Regex regex = new Regex(nameof(Baz.MyProperty), RegexOptions.IgnoreCase);
            var matches = regex.Matches(json);

            Assert.AreEqual(myPropertyNumberOccurences, matches.Count);
        }

        [Test]
        [TestCase(nameof(Baz.ShouldBeIgnoredOnClassLevel))]
        [TestCase(nameof(Baz.ShouldIgnoreInterfaceLevelProperty))]
        public void ShouldIgnoreJsonIgnoreClassLevelPropertiesWithDefaultConverter(string propertyName)
        {
            // Remove the default converters
            _subject.JsonConverters = new List<JsonConverter>();

            var json = _subject.Serialize(TestFoo.GetDefaultFoo());

            Regex regex = new Regex(
                propertyName,
                RegexOptions.IgnoreCase
            );
            var matches = regex.Matches(json);

            Assert.AreEqual(0, matches.Count(), nameof(matches));
        }

        [Test]
        [TestCase(nameof(Baz.ShouldBeIgnoredOnClassLevel))]
        [TestCase(nameof(Baz.ShouldIgnoreInterfaceLevelProperty))]
        public void ShouldIgnoreJsonIgnoreClassLevelPropertiesWithCustomConverter(string propertyName)
        {
            var json = _subject.Serialize(TestFoo.GetDefaultFoo());

            Regex regex = new Regex(
                propertyName, 
                RegexOptions.IgnoreCase
            );
            var matches = regex.Matches(json);

            Assert.AreEqual(0, matches.Count(), nameof(matches));
        }
    }
}
