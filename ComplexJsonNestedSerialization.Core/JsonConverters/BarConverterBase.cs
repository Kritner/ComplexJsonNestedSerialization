using ComplexJsonNestedSerialization.Core.Interfaces;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    public abstract class BarConverterBase<TBar, TBaz> : ConverterBase<TBar>
        where TBar : IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
    }
}
