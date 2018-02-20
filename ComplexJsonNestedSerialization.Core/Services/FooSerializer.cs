using System.Collections.Generic;
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

    public virtual List<JsonConverter> JsonConverters { get; set; } =
        new List<JsonConverter>()
        {
            new BazConverterClient()
        };

    public string Serialize(IFoo<TBar, TBaz> foo)
        {
            return JsonConvert.SerializeObject(
                foo,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented,
                    Converters = JsonConverters,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            );
        }
    }
}
