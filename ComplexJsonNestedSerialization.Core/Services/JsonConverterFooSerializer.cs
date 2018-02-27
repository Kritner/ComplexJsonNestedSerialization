using ComplexJsonNestedSerialization.Core.Enums;
using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ComplexJsonNestedSerialization.Core.Services
{
    public class JsonConverterFooSerializer : IFooSerializer
    {
        private readonly IJsonConvertersFactory _jsonConvertersFactory;

        public JsonConverterFooSerializer(IJsonConvertersFactory jsonConvertersFactory)
        {
            _jsonConvertersFactory = jsonConvertersFactory;
        }

        public string Serialize(IFoo<IBar<IBaz>> foo, Projection projection)
        {
            var converters = _jsonConvertersFactory.GetConvertersForProjection(projection);

            return JsonConvert.SerializeObject(
                foo,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    Converters = converters,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            );
        }
    }
}
