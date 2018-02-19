using ComplexJsonNestedSerialization.Core.Interfaces;
using ComplexJsonNestedSerialization.Core.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Models
{
    public class Bar : IBar
    {
        public int Id { get; set; }
        public bool ShouldSerializeSomeBazProperty { get; set; }
        [JsonConverter(typeof(ConcreteConverter<IEnumerable<Baz>>))]
        public IEnumerable<IBaz> Bazes { get; set; }
    }
}