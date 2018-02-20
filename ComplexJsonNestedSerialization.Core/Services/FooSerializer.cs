using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Services
{
    public class FooSerializer<TBar, TBaz> : IFooSerializer<TBar, TBaz>
        where TBar : IBar<TBaz>
        where TBaz : IBaz
    {
        public string Serialize(IFoo<TBar, TBaz> foo)
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
