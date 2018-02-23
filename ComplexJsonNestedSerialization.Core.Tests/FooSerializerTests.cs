using System.Collections.Generic;
using System.Dynamic;
using NUnit.Framework;
using ComplexJsonNestedSerialization.Core.Models;
using ComplexJsonNestedSerialization.Core.Services;
using System.Linq;
using System.Text.RegularExpressions;
using ComplexJsonNestedSerialization.Core.Factories;
using ComplexJsonNestedSerialization.Core.Enums;
using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Tests
{
    [TestFixture]
    public class FooSerializerTests
    {

        private FooSerializer<Bar, Baz> _subject;
        private readonly IJsonConvertersFactory _jsonConverterFactory = 
            new JsonConvertersFactory();

        [SetUp]
        public void Setup()
        {
            _subject = new FooSerializer<Bar, Baz>(_jsonConverterFactory);
        }
        
        [Test]
        [TestCase(Projection.Client, 3)]
        [TestCase(Projection.Server, 4)]
        [TestCase(Projection.None, 4)]
        public void ShouldExcludeRakatakaMyPropertyWithClientProjection(Projection projection, int myPropertyNumberOccurences)
        {
            var json = _subject.Serialize(TestFoo.GetDefaultFoo(), projection);

            Regex regex = new Regex(nameof(Baz.MyProperty), RegexOptions.IgnoreCase);
            var matches = regex.Matches(json);

            Assert.AreEqual(myPropertyNumberOccurences, matches.Count);
        }

        [Test]
        [TestCase(nameof(Baz.ShouldBeIgnoredOnClassLevel))]
        [TestCase(nameof(Baz.ShouldIgnoreInterfaceLevelProperty))]
        public void ShouldIgnoreJsonIgnoreClassLevelPropertiesWithDefaultConverter(string propertyName)
        {
            var json = _subject.Serialize(TestFoo.GetDefaultFoo(), Projection.None);

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
            var json = _subject.Serialize(TestFoo.GetDefaultFoo(), Projection.Client);

            Regex regex = new Regex(
                propertyName, 
                RegexOptions.IgnoreCase
            );
            var matches = regex.Matches(json);

            Assert.AreEqual(0, matches.Count(), nameof(matches));
        }

        [Test]
        [TestCase(TestEnum.ThisIsTheFirstPart, "ThisIsTheFirstPart")]
        [TestCase(TestEnum.Lmao, "Ayyy")]
        [TestCase(TestEnum.HereIsAnother, "HereIsAnother")]
        public void ShouldSerializeEnumDescriptionOrName(TestEnum testEnum, string expectedSerializationValue)
        {
            var json = JsonConvert.SerializeObject(
                testEnum, 
                Formatting.Indented, 
                new StringEnumConverter()
            );

            Assert.AreEqual($@"""{expectedSerializationValue}""", json);
        }

        [Test]
        [TestCase(TestEnum.ThisIsTheFirstPart, @"""ThisIsTheFirstPart""")]
        [TestCase(TestEnum.Lmao, @"""Ayyy""")]
        [TestCase(TestEnum.HereIsAnother, @"""HereIsAnother""")]
        public void ShouldDeserializeEnumDescriptionOrName(TestEnum expectedEnum, string json)
        {
            var result = JsonConvert.DeserializeObject<TestEnum>(json, new JsonSerializerSettings()
            {
                Converters = new List<JsonConverter>()
                {
                    new StringEnumConverter()
                }
            });

            Assert.AreEqual(result, expectedEnum);
        }
    }
}
