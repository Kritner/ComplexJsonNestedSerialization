using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooProvider<TBar, TBaz>
        where TBar : IBar<TBaz>
        where TBaz : IBaz
    {
        IFoo<TBar, TBaz> GetFoo();
    }
}
