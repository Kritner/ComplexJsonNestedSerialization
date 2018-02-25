using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComplexJsonNestedSerialization.Core.Interfaces
{
    public interface IBarConverter<TBar, TBaz>
        where TBar : IBar<TBar, TBaz>
        where TBaz : IBaz<TBar>
    {
        void WriteJson(JsonWriter writer, TBar bar, JsonSerializer serializer);
    }
}
