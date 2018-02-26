using System;
using System.Linq;
using ComplexJsonNestedSerialization.Core.Models;
using Newtonsoft.Json.Serialization;

namespace ComplexJsonNestedSerialization.Core.ContractResolvers
{
    /// <summary>
    /// The client's projection of the <see cref="Bar"/> and <see cref="Baz"/> classes.
    /// Client projection excludes some information from both Bar and Baz.
    /// </summary>
    public class ClientProjectionContractResolver : ProjectionContractResolverBase
    {
        public static readonly ClientProjectionContractResolver Instance = new ClientProjectionContractResolver();

        protected override Predicate<object> ShouldSerialize(JsonProperty jsonProperty)
        {
            var type = jsonProperty.DeclaringType;

            if (type == typeof(Bar))
            {
                return BarSerialization(jsonProperty);
            }

            if (type == typeof(Baz))
            {
                return BazSerialization(jsonProperty);
            }

            return jsonProperty.ShouldSerialize;
        }

        /// <summary>
        /// Only include the Id and Bazes
        /// </summary>
        /// <param name="jsonProperty"></param>
        /// <returns></returns>
        private Predicate<object> BarSerialization(JsonProperty jsonProperty)
        {
            var includeProperties = new[]
            {
                nameof(Bar.Id),
                nameof(Bar.Bazes)
            };

            if (includeProperties.Contains(jsonProperty.UnderlyingName, StringComparer.OrdinalIgnoreCase))
            {
                return jsonProperty.ShouldSerialize =
                    instance => true;
            }

            return jsonProperty.ShouldSerialize =
                instance => false;
        }

        private Predicate<object> BazSerialization(JsonProperty jsonProperty)
        {
            // let's just omit the "MyProperty" when its value is "rakataka"
            if (jsonProperty.UnderlyingName == nameof(Baz.MyProperty))
            {
                return jsonProperty.ShouldSerialize =
                    instance =>
                    {
                        Baz baz = (Baz) instance;
                        return baz.MyProperty != "rakataka";
                    };
            }

            //// Omit the "ShouldIncludeWhenBarSpecifies" property in Baz, 
            //// when Bar's "ShouldIncludeBazProperty" specifies
            if (jsonProperty.UnderlyingName == nameof(Baz.ShouldIncludeWhenBarSpecifies))
            {
                return jsonProperty.ShouldSerialize =
                    instance =>
                    {
                        Baz baz = (Baz)instance;
                        return baz.Parent.ShouldIncludeBazProperty;
                    };
            }

            return jsonProperty.ShouldSerialize;
        }
    }
}
