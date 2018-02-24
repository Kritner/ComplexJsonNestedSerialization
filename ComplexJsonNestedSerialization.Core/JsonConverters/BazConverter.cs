using System.Reflection;
using ComplexJsonNestedSerialization.Core.Interfaces;
using ComplexJsonNestedSerialization.Core.Models;

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

    /// <summary>
    /// Property omitted from projection (just using a random one as an example)
    /// </summary>
    public class BazConverterClient : BazConverterBase<Bar, Baz>
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
