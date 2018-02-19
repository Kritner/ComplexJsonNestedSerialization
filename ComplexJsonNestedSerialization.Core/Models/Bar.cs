using ComplexJsonNestedSerialization.Core.Interfaces;
using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Models
{
    public class Bar : IBar
    {
        public int Id { get; set; }
        public bool ShouldSerializeSomeBazProperty { get; set; }
        public IEnumerable<IBaz> Bazes { get; set; }
    }
}