using System;
using System.ComponentModel.DataAnnotations;

namespace ElasticSearchPoC.Common.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayValue(this Enum value)
        {
            var type = value.GetType();

            var fieldInfo = type.GetField(value.ToString());
            var attributes = fieldInfo?.GetCustomAttributes(typeof(Attribute), false) as Attribute[];

            if (attributes != null && attributes.Length > 0)
            {
                return (attributes[0] as DisplayAttribute)?.Name;
            }

            return string.Empty;
        }
    }
}