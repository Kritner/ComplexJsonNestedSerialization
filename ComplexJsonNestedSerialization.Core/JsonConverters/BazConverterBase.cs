using ComplexJsonNestedSerialization.Core.Interfaces;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    public abstract class BazConverterBase<TBar, TBaz> : ConverterBase<TBaz>
        where TBar : IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
    }
}
