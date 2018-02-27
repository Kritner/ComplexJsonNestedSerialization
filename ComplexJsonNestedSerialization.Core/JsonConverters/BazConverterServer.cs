using ComplexJsonNestedSerialization.Core.Interfaces;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    /// <summary>
    /// All properties included in server projection
    /// </summary>
    /// <typeparam name="TBaz">The type to serialize</typeparam>
    public class BazConverterServer<TBaz> : BazConverterBase<TBaz>
        where TBaz : IBaz
    {
    }
}
