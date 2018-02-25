using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IJsonConverter<in T>
    {
        void WriteJson(JsonWriter writer, T t, JsonSerializer serializer);
    }
}
