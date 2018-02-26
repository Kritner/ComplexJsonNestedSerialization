using ComplexJsonNestedSerialization.Core.Enums;
using Newtonsoft.Json.Serialization;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IContractResolverFactory
    {
        IContractResolver GetContractResolver(Projection projection);
    }
}