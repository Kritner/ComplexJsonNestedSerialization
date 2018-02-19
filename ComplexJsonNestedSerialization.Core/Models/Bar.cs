using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Models
{
    public class Bar
    {
        public int Id { get; set; }
        public bool ShouldSerializeSomeBazProperty { get; set; }
        public IEnumerable<Baz> Bazez { get; set; }
    }
}