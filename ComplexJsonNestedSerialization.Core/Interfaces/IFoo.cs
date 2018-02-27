using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFoo<out TBar>
        where TBar : IBar<IBaz>
    {
        int Id { get; set; }
        IEnumerable<TBar> Bars { get; }
    }
}