using ComplexJsonNestedSerialization.Core.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IJsonConvertersFactory
    {
        IList<JsonConverter> GetConvertersForProjection(Projection projection);
    }
}