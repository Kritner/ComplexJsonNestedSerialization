using System.Reflection;
using ComplexJsonNestedSerialization.Core.Models;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    /// <summary>
    /// Bar serialization - only include the ID and Bazes
    /// </summary>
    public class BarConverterClient : BarConverterBase<Bar, Baz>
    {
        /// <summary>
        /// Only includes the ID and Bazes
        /// </summary>
        /// <param name="t">The type</param>
        /// <param name="prop">The property info</param>
        /// <returns></returns>
        protected override bool IsPropertyIncluded(Bar t, PropertyInfo prop)
        {
            // include Id
            if (prop.Name == nameof(t.Id))
            {
                return true;
            }

            // include bazes
            if (prop.Name == nameof(t.Bazes))
            {
                return true;
            }

            // everything else excluded
            return false;
        }
    }
}
