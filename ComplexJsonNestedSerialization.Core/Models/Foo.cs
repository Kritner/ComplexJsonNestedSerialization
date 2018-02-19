using ComplexJsonNestedSerialization.Core.Interfaces;
using ComplexJsonNestedSerialization.Core.JsonConverters;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Models
{
    public class Foo : IFoo
    {
        public int Id { get; set; }
        [JsonConverter(typeof(ConcreteConverter<IEnumerable<Bar>>))]
        public IEnumerable<IBar> Bars { get; set; }
    }
}
