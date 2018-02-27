using ComplexJsonNestedSerialization.Core.Enums;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooSerializer
    {
        string Serialize(IFoo<IBar<IBaz>> foo, Projection projection);
    }
}
