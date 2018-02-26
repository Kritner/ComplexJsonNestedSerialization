using ComplexJsonNestedSerialization.Core.Enums;
using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ComplexJsonNestedSerialization.Core.Services
{
    public class JsonConverterFooSerializer<TBar, TBaz> : IFooSerializer<TBar, TBaz>
        where TBar : IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
        private readonly IJsonConvertersFactory _jsonConvertersFactory;

        public JsonConverterFooSerializer(IJsonConvertersFactory jsonConvertersFactory)
        {
            _jsonConvertersFactory = jsonConvertersFactory;
        }

        public string Serialize(IFoo<TBar, TBaz> foo, Projection projection)
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
