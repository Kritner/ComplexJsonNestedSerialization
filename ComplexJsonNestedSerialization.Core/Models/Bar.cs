using ComplexJsonNestedSerialization.Core.Interfaces;
using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Models
{
    public class Bar : IBar<Baz>
    {
        public int Id { get; set; }
        public bool ShouldSerializeSomeBazProperty { get; set; }
        public IEnumerable<Baz> Bazes { get; set; }
    }
}