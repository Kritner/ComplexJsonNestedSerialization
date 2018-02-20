using System;
using System.Reflection;
using ComplexJsonNestedSerialization.Core.Interfaces;
using ComplexJsonNestedSerialization.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    /// <summary>
    /// All properties included in server projection
    /// </summary>
    /// <typeparam name="TBaz">The type to serialize</typeparam>
    public class BazConverterServer<TBaz> : BazConverterBase<TBaz>
        where TBaz : IBaz
    {
        public override void WriteJson(JsonWriter writer, TBaz baz, JsonSerializer serializer)
        {
            JObject jo = new JObject();

            foreach (PropertyInfo prop in GetPublicProperties(baz))
            {
                if (prop.CanRead)
                {
                    object propVal = prop.GetValue(baz, null);
                    if (propVal != null)
                    {
                        jo.Add(prop.Name, JToken.FromObject(propVal, serializer));
                    }
                }
            }
            jo.WriteTo(writer);
        }
    }

    /// <summary>
    /// Property omitted from projection (just using a random one as an example)
    /// </summary>
    public class BazConverterClient : BazConverterBase<Baz>
    {
        public override void WriteJson(JsonWriter writer, Baz baz, JsonSerializer serializer)
        {
            JObject jo = new JObject();

            foreach (PropertyInfo prop in GetPublicProperties(baz))
            {
                if (prop.CanRead)
                {
                    object propVal = prop.GetValue(baz, null);

                    // let's just omit the "MyProperty" when its value is "rakataka"
                    if (prop.Name == nameof(baz.MyProperty) && baz.MyProperty == "rakataka")
                    {
                        continue;
                    }

                    if (propVal != null)
                    {
                        jo.Add(prop.Name, JToken.FromObject(propVal, serializer));
                    }
                }
            }
            jo.WriteTo(writer);
        }
    }
}
