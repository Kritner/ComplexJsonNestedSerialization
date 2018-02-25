using ComplexJsonNestedSerialization.Core.Interfaces;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    /// <summary>
    /// All properties included in server projection
    /// </summary>
    /// <typeparam name="TBaz">The type to serialize</typeparam>
    public class BazConverterServer<TBar, TBaz> : BazConverterBase<TBar, TBaz>
        where TBar : IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
    }
}
