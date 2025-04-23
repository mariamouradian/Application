using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Seminar7_HW
{
    [AttributeUsage(AttributeTargets.Field)]
    public class CustomNameAttribute : Attribute
    {
        public string CustomFieldName { get; }

        public CustomNameAttribute(string customFieldName)
        {
            CustomFieldName = customFieldName;
        }
    }

    public static class SerializationHelper
    {
        public static string ObjectToString(object obj)
        {
            var fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var entries = new List<string>();

            foreach (var field in fields)
            {
                var customNameAttribute = field.GetCustomAttribute<CustomNameAttribute>();
                var fieldName = customNameAttribute?.CustomFieldName ?? field.Name;
                var fieldValue = field.GetValue(obj);

                entries.Add($"{fieldName}:{fieldValue}");
            }

            return string.Join(",", entries);
        }

        public static void StringToObject(object obj, string data)
        {
            var entries = data.Split(',');
            var fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var entry in entries)
            {
                var parts = entry.Split(':');
                if (parts.Length != 2) continue;

                var fieldName = parts[0];
                var valueStr = parts[1];

                FieldInfo field = null;

                field = fields.FirstOrDefault(f => f.Name == fieldName);

                if (field == null)
                {
                    field = fields.FirstOrDefault(f =>
                        f.GetCustomAttribute<CustomNameAttribute>()?.CustomFieldName == fieldName);
                }

                if (field != null)
                {
                    object value = Convert.ChangeType(valueStr, field.FieldType);
                    field.SetValue(obj, value);
                }
            }
        }
    }
}
