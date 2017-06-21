using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inilib
{
    public static class ClassHandler
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector)  where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
            
            if (att != null)
            {
                return valueSelector(att);
            }
            return default(TValue);
        }

        public static ClassAttribute[] GetAttributes(Object obj)
        {
            List<ClassAttribute> attributes = new List<ClassAttribute>();
            Type type = obj.GetType();

            foreach (var prop in type.GetProperties())
            {
                attributes.Add(new ClassAttribute(prop.Name, prop.GetValue(obj, null).ToString()));
            }

            return attributes.ToArray();
        }
    }
}
