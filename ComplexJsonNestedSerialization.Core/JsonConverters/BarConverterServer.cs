using ComplexJsonNestedSerialization.Core.Interfaces;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    /// <summary>
    /// All properties included
    /// </summary>
    /// <typeparam name="TBar"></typeparam>
    /// <typeparam name="TBaz"></typeparam>
    public class BarConverterServer<TBar> : BarConverterBase<TBar>
        where TBar : IBar<IBaz>
    {
    }
}
