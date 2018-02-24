using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooProvider<TBar, TBaz>
        where TBar : IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
        IFoo<TBar, TBaz> GetFoo();
    }
}
