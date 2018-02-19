using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBar
    {
        IEnumerable<IBaz> Bazes { get; set; }
        int Id { get; set; }
    }
}