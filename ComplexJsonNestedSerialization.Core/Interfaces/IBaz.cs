using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBaz<TBar>
    {
        int Id { get; set; }
        [JsonIgnore]
        TBar Parent { get; }
        [JsonIgnore]
        bool ShouldIgnoreInterfaceLevelProperty { get; set; }
        bool ShouldIncludeWhenBarSpecifies { get; set; }
    }
}