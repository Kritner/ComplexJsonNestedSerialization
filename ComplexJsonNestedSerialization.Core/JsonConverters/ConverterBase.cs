using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    public abstract class ConverterBase<T> : JsonConverter, IJsonConverter<T>
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(T));
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<T>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is T t)
            {
                WriteJson(writer, t, serializer);
                return;
            }

            throw new ArgumentException($"{nameof(value)} was incorrect type");
        }

        public virtual void WriteJson(JsonWriter writer, T t, JsonSerializer serializer)
        {
            JObject jo = new JObject();
            
            foreach (PropertyInfo prop in GetPublicProperties(t))
            {
                if (prop.CanRead && IsPropertyIncluded(t, prop))
                {
                    object propVal = prop.GetValue(t, null);
                    if (propVal != null)
                    {
                        var propName = GetPrintablePropertyName(prop);
                        jo.Add(propName, JToken.FromObject(propVal, serializer));
                    }
                }
            }
            jo.WriteTo(writer);
        }

        protected virtual bool IsPropertyIncluded(T t, PropertyInfo prop)
        {
            return true;
        }

        protected string GetPrintablePropertyName(PropertyInfo prop)
        {
            var jsonProp = prop.GetCustomAttribute<JsonPropertyAttribute>();
            if (!string.IsNullOrEmpty(jsonProp?.PropertyName))
            {
                return jsonProp.PropertyName;
            }

            return prop.Name;
        }

        protected IEnumerable<PropertyInfo> GetPublicProperties(T t)
        {
            Type type = typeof(T);
            var props =
                type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    // Only include properties that don't have the JsonIgnore attribute    
                    .Where(w => !Attribute.IsDefined(w, typeof(JsonIgnoreAttribute), true))
                    .ToList();

            // Apparently "true" on Attribute.IsDefined doesn't work how I'd expect it too.
            var tInt = type.GetInterfaces();
            foreach (var i in tInt)
            {
                var iProps = i.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(w => Attribute.IsDefined(w, typeof(JsonIgnoreAttribute), true))
                    .ToList();

                // Remove properties from props that have an 
                // interface property containing the JsonIgnore attribute
                props.RemoveAll(r => iProps.Select(s => s.Name).Contains(r.Name));
            }

            return props;
        }
    }
}
