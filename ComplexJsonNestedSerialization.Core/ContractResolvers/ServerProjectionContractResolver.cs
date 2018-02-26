using System;
using ComplexJsonNestedSerialization.Core.Models;
using Newtonsoft.Json.Serialization;

namespace ComplexJsonNestedSerialization.Core.ContractResolvers
{
    /// <summary>
    /// The server's projection of the <see cref="Bar"/> and <see cref="Baz"/> classes.
    /// Server projection should include everything not excluded via attributes.
    /// </summary>
    public class ServerProjectionContractResolver : ProjectionContractResolverBase
    {
        /// <summary>
        /// Nothing to filter specific to the server, return existing predicate.
        /// </summary>
        /// <param name="jsonProperty"></param>
        /// <returns></returns>
        protected override Predicate<object> ShouldSerialize(JsonProperty jsonProperty)
        {
            return jsonProperty.ShouldSerialize;
        }
    }
}
