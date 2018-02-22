using System.Collections.Generic;
using ComplexJsonNestedSerialization.Core.Enums;
using ComplexJsonNestedSerialization.Core.Interfaces;
using ComplexJsonNestedSerialization.Core.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ComplexJsonNestedSerialization.Core.Services
{
    public class FooSerializer<TBar, TBaz> : IFooSerializer<TBar, TBaz>
        where TBar : IBar<TBaz>
        where TBaz : IBaz
    {
        private readonly IJsonConvertersFactory _jsonConvertersFactory;

        public FooSerializer(IJsonConvertersFactory jsonConvertersFactory)
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
