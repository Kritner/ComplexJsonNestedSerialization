using ComplexJsonNestedSerialization.Core.Interfaces;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    public abstract class BarConverterBase<TBar> : ConverterBase<TBar>
        where TBar : IBar<IBaz>
    {
    }
}
