using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    interface IFooProvider
    {
        IEnumerable<IFoo> GetFoos();
    }
}
