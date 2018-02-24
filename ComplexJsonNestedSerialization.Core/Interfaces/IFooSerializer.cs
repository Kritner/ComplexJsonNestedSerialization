using ComplexJsonNestedSerialization.Core.Enums;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IFooSerializer<TBar, TBaz>
        where TBar : IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
        string Serialize(IFoo<TBar, TBaz> foo, Projection projection);
    }
}
