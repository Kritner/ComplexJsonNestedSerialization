using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBaz<TBar>
    {
        int Id { get; set; }
        TBar Parent { get; }
        [JsonIgnore]
        bool ShouldIgnoreInterfaceLevelProperty { get; set; }
    }
}