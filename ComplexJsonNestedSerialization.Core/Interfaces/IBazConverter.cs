using System;
using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBazConverter<TBar, in TBaz>
        where TBaz : IBaz<TBar>
        where TBar : IBar<TBar, TBaz>
    {
        void WriteJson(JsonWriter writer, TBaz baz, JsonSerializer serializer);
    }
}
