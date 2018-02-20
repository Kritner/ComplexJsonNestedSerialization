using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFoo<TBar, TBaz>
        where TBar : IBar<TBaz>
        where TBaz : IBaz
    {
        IEnumerable<TBar> Bars { get; set; }
        int Id { get; set; }
    }
}