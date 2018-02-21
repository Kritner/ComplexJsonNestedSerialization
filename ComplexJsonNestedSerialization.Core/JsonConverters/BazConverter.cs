using System.Reflection;
using ComplexJsonNestedSerialization.Core.Interfaces;
using ComplexJsonNestedSerialization.Core.Models;

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

    /// <summary>
    /// Property omitted from projection (just using a random one as an example)
    /// </summary>
    public class BazConverterClient : BazConverterBase<Baz>
    {
        protected override bool IsPropertyIncluded(Baz baz, PropertyInfo prop)
        {
            // let's just omit the "MyProperty" when its value is "rakataka"
            if (prop.Name == nameof(baz.MyProperty) && baz.MyProperty == "rakataka")
            {
                return false;
            }

            return true;
        }
    }
}
