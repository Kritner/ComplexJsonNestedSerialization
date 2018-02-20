using System;
using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBazConverter<in TBaz>
        where TBaz : IBaz
    {
        void WriteJson(JsonWriter writer, TBaz baz, JsonSerializer serializer);
    }
}
