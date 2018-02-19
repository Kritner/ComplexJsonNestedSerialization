using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Services
{
    public class FooSerializer : IFooSerializer
    {
        public string Serialize(IFoo foo)
        {
            return JsonConvert.SerializeObject(
                foo,
                new JsonSerializerSettings()
                {
                    Formatting = Formatting.Indented
                }
            );
        }
    }
}
