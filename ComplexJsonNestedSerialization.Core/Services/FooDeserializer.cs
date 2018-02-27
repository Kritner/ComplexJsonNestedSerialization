using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Services
{
    public class FooDeserializer<TFoo> : IFooDeserializer<TFoo>
        where TFoo : IFoo<IBar<IBaz>>
    {
        public TFoo Deserialize(string fooJson)
        {
            return JsonConvert.DeserializeObject<TFoo>(
                fooJson
            );
        }
    }
}
