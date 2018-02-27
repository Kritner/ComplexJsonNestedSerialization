using ComplexJsonNestedSerialization.Core.Enums;
using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ComplexJsonNestedSerialization.Core.Services
{
    public class ContractResolverFooSerializer : IFooSerializer
    {
        private readonly IJsonConvertersFactory _jsonConvertersFactory;
        private readonly IContractResolverFactory _contractResolverFactory;

        public ContractResolverFooSerializer(IJsonConvertersFactory jsonConvertersFactory, IContractResolverFactory contractResolverFactory)
        {
            _jsonConvertersFactory = jsonConvertersFactory;
            _contractResolverFactory = contractResolverFactory;
        }

        public string Serialize(IFoo<IBar<IBaz>> foo, Projection projection)
        {
            // using "None" projection as we still want the default converters
            var converters = _jsonConvertersFactory.GetConvertersForProjection(Projection.None);
            var contractResolver = _contractResolverFactory.GetContractResolver(projection);

            return JsonConvert.SerializeObject(
                foo,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    Converters = converters,
                    ContractResolver = contractResolver
                }
            );
        }
    }
}
