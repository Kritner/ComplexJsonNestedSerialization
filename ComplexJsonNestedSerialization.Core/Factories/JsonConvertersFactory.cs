using ComplexJsonNestedSerialization.Core.Enums;
using ComplexJsonNestedSerialization.Core.Interfaces;
using ComplexJsonNestedSerialization.Core.JsonConverters;
using ComplexJsonNestedSerialization.Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ComplexJsonNestedSerialization.Core.Factories
{
    public class JsonConvertersFactory : IJsonConvertersFactory
    {
        public IList<JsonConverter> GetConvertersForProjection(Projection projection)
        {
            List<JsonConverter> list = new List<JsonConverter>();

            switch (projection)
            {
                case Projection.Client:
                    list.Add(new BazConverterClient());
                    break;
                case Projection.Server:
                    list.Add(new BazConverterServer<Baz>());
                    break;
                case Projection.None:
                default:
                    break;
            }

            return list;
        }
    }
}
