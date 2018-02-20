using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBar<TBaz>
        where TBaz : IBaz
    {
        IEnumerable<TBaz> Bazes { get; set; }
        int Id { get; set; }
    }
}