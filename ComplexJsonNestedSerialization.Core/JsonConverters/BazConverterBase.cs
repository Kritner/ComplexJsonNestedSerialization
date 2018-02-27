using ComplexJsonNestedSerialization.Core.Interfaces;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    public abstract class BazConverterBase<TBaz> : ConverterBase<TBaz>
        where TBaz : IBaz
    {
    }
}
