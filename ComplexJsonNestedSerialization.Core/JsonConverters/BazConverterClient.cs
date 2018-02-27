using System.Reflection;
using ComplexJsonNestedSerialization.Core.Models;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
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

            // Omit the "ShouldIncludeWhenBarSpecifies" property in Baz, 
            // when Bar's "ShouldIncludeBazProperty" specifies
            if (prop.Name == nameof(baz.ShouldIncludeWhenBarSpecifies) 
                && !((Bar)baz.Parent).ShouldIncludeBazProperty)
            {
                return false;
            }

            return true;
        }
    }
}
