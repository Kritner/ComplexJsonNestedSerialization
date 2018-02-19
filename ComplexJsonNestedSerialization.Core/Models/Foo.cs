using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexJsonNestedSerialization.Core.Models
{
    public class Foo
    {
        public int Id { get; set; }
        public IEnumerable<Bar> Bars { get; set; }
    }
}
