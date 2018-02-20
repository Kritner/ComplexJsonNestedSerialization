using ComplexJsonNestedSerialization.Core.Interfaces;
using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Models
{
    public class Foo : IFoo<Bar, Baz>
    {
        public int Id { get; set; }
        public IEnumerable<Bar> Bars { get; set; }
    }
}
