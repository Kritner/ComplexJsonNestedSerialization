using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBaz
    {
        int Id { get; set; }
        [JsonIgnore]
        IBar<IBaz> Parent { get; }
        [JsonIgnore]
        bool ShouldIgnoreInterfaceLevelProperty { get; set; }
        bool ShouldIncludeWhenBarSpecifies { get; set; }
    }
}