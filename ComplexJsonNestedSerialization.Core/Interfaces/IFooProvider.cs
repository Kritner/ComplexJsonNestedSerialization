using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooProvider
    {
        IFoo<IBar<IBaz>> GetFoo();
    }
}
