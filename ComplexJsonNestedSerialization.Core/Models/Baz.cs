using ComplexJsonNestedSerialization.Core.Enums;
using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.Models
{
    public class Baz : IBaz
    {
        public int Id { get; set; }
        public string MyProperty { get; set; }
        public string AnotherProperty { get; set; }
        public int AndYetAnotherProperty { get; set; }
        [JsonIgnore]
        public bool ShouldBeIgnoredOnClassLevel { get; set; }
        public bool ShouldIgnoreInterfaceLevelProperty { get; set; }
        [JsonProperty("RenamedProperty")]
        public TestEnum TestEnumDeSerializedAsDescriptionOrName { get; set; }
    }
}