using ComplexJsonNestedSerialization.Core.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace ComplexJsonNestedSerialization.Core.ContractResolvers
{
    /// <summary>
    /// Base class for defining separate serializations,
    /// depending on a projection's intended audience.
    /// </summary>
    public abstract class ProjectionContractResolverBase : CamelCasePropertyNamesContractResolver
    {
        /// <summary>
        /// Override the base <see cref="DefaultContractResolver.CreateProperty"/>.
        /// Continues to call the base method, as well as an additional method to check
        /// if a property should be serialized.
        /// </summary>
        /// <param name="member">The member being considered for serialization.</param>
        /// <param name="memberSerialization">Member serialization options</param>
        /// <returns></returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);
            jsonProperty.ShouldSerialize = ShouldSerialize(jsonProperty);

            return jsonProperty;
        }

        /// <summary>
        /// Additional checks on if <see cref="jsonProperty"/> should be serialized.
        /// </summary>
        /// <param name="jsonProperty">The property being considered for serialization.</param>
        /// <returns></returns>
        protected abstract Predicate<object> ShouldSerialize(JsonProperty jsonProperty);
    }
}
