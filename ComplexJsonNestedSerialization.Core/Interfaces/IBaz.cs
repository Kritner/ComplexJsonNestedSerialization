using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBaz
    {
        int Id { get; set; }
        [JsonIgnore]
        bool ShouldIgnoreInterfaceLevelProperty { get; set; }
    }
}