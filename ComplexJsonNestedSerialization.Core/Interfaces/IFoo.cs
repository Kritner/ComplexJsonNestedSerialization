using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFoo
    {
        IEnumerable<IBar> Bars { get; set; }
        int Id { get; set; }
    }
}