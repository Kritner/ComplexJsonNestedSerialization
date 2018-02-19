using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBar
    {
        IEnumerable<IBaz> Bazez { get; set; }
        int Id { get; set; }
    }
}