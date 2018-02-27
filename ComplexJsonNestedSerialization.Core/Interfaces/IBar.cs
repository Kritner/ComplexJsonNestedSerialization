using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBar<out TBaz>
        where TBaz : IBaz
    {
        int Id { get; set; }
        IEnumerable<TBaz> Bazes { get; }
    }
}