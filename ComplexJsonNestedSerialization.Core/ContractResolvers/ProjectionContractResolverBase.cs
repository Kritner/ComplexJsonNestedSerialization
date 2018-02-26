using ComplexJsonNestedSerialization.Core.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Reflection;

namespace ComplexJsonNestedSerialization.Core.ContractResolvers
{
    /// <summary>
    /// TODO maybe... struggling between ContractResolver and JsonConverter.
    /// Seems like both have their pros and cons
    /// </summary>
    /// <typeparam name="TObject"></typeparam>
    public abstract class ProjectionContractResolver<TObject> : CamelCasePropertyNamesContractResolver
    {

        protected Projection Projection { get; }
        protected TObject ObjectToDeSerialize { get; }

        protected ProjectionContractResolver(TObject objectToDeSerialize, Projection projection)
        {
            Projection = projection;
            ObjectToDeSerialize = objectToDeSerialize;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);
            jsonProperty.ShouldSerialize = ShouldSerialize(member, jsonProperty);

            return jsonProperty;
        }

        protected abstract Predicate<object> ShouldSerialize(MemberInfo member, JsonProperty jsonProperty);
    }
}
