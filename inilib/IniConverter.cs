using inilib.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace inilib
{
    public class IniConverter
    {       
        public static T[] DeserializeObject<T>(String[] lines)
        {
            List<T> objects = new List<T>();

            IniFile iniFile = IniFile.Get(lines);
            
            foreach (Section section in iniFile.sections)
            {
                T instance = (T) Activator.CreateInstance(typeof(T));
                
                foreach (Key key in section.Keys)
                {
                    PropertyInfo propKey = instance.GetType().GetProperty(key.Name);
                    var convertedValue = Convert.ChangeType(key.Value, propKey.PropertyType);
                    propKey.SetValue(instance, convertedValue, null);
                }

                objects.Add(instance);
            }

            return objects.ToArray();
            
        }

        public static T[] DeserializeObject<T>(String Path)
        {
            return DeserializeObject<T>(Archive.ReadLineFromFile(Path));
        }

        public static String[] SerializeObject(Object obj)
        {
            return ObjectToIniFile(new IniFile(), obj).ConvertToString();
        }

        public static IniFile ObjectToIniFile(IniFile ini, Object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            Section currentSection = new Section(obj.GetType().Name);

            foreach (PropertyInfo property in properties)
            {
                //if (property.GetType().IsClass)
                //{
                //    ObjectToIniFile(ini, property);
                //}
                //else
                //{
                    currentSection.Keys.Add(new Key(property.Name.ToString(), property.GetValue(obj, null).ToString()));
                //}
            }

            ini.sections.Add(currentSection);
            return ini;
        }

        public static IniFile DeserializeToInifile(String path)
        {
            return IniFile.Get(path);
        }
    }
}
