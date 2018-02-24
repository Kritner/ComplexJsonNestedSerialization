using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFoo<TBar, TBaz>
        where TBar : IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
        IEnumerable<TBar> Bars { get; set; }
        int Id { get; set; }
    }
}