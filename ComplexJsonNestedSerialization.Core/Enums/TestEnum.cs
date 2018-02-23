using System.ComponentModel;
using System.Runtime.Serialization;

namespace ComplexJsonNestedSerialization.Core.Enums
{
    public enum TestEnum
    {
        ThisIsTheFirstPart,
        [EnumMember(Value = "Ayyy")]
        Lmao,
        HereIsAnother
    }
}