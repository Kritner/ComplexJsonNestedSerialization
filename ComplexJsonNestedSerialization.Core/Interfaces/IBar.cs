using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
        IEnumerable<TBaz> Bazes { get; set; }
        int Id { get; set; }
    }
}