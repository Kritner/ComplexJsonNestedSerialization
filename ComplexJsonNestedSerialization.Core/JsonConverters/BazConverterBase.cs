﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ComplexJsonNestedSerialization.Core.Interfaces;
using Newtonsoft.Json;

namespace ComplexJsonNestedSerialization.Core.JsonConverters
{
    public abstract class BazConverterBase<TBaz> : JsonConverter, IBazConverter<TBaz>
        where TBaz : IBaz
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(TBaz));
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<TBaz>(reader);
        }

        public abstract void WriteJson(JsonWriter writer, TBaz baz, JsonSerializer serializer);
        
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is TBaz tBaz)
            {
                WriteJson(writer, tBaz, serializer);
                return;
            }

            throw new ArgumentException($"{nameof(value)} was incorrect type");
        }

        protected IEnumerable<PropertyInfo> GetPublicProperties(TBaz tBaz)
        {
            Type t = typeof(TBaz);
            var props =
                t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    // Only include properties that don't have the JsonIgnore attribute    
                    .Where(w => !Attribute.IsDefined(w, typeof(JsonIgnoreAttribute), true))
                    .ToList();

            // Apparently "true" on Attribute.IsDefined doesn't work how I'd expect it too.
            var tInt = t.GetInterfaces();
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
