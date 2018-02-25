using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
        int Id { get; set; }
        IEnumerable<TBaz> Bazes { get; set; }
        bool ShouldIncludeBazProperty { get; set; }
    }
}