using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Services
{
    public class FooDeserializer<TFoo, TBar, TBaz> : IFooDeserializer<TFoo, TBar, TBaz>
        where TFoo : IFoo<TBar, TBaz>
        where TBar : IBar<TBaz>
        where TBaz : IBaz
    {
        public TFoo Deserialize(string fooJson)
        {
            return JsonConvert.DeserializeObject<TFoo>(
                fooJson
            );
        }
    }
}
