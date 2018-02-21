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
        public void ShouldIgnoreJsonIgnoreClassLevelPropertiesWithDefaultConverter()
        {
            // Remove the default converters
            _subject.JsonConverters = new List<JsonConverter>();

            var json = _subject.Serialize(TestFoo.GetDefaultFoo());

            Regex regex = new Regex(
                nameof(Baz.ShouldBeIgnoredOnClassLevel),
                RegexOptions.IgnoreCase
            );
            var matches = regex.Matches(json);

            Assert.AreEqual(0, matches.Count(), nameof(matches));
        }

        [Test]
        public void ShouldIgnoreJsonIgnoreClassLevelPropertiesWithCustomConverter()
        {
            var json = _subject.Serialize(TestFoo.GetDefaultFoo());

            Regex regex = new Regex(
                nameof(Baz.ShouldBeIgnoredOnClassLevel), 
                RegexOptions.IgnoreCase
            );
            var matches = regex.Matches(json);

            Assert.AreEqual(0, matches.Count(), nameof(matches));
        }
    }
}
