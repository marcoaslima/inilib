using inilib.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace inilib
{
    public class IniFile
    {
        public List<Section> sections { get; set; }
        
        public IniFile()
        {
            this.sections = new List<Section>();
        }

        public static IniFile Get(String Path)
        {
            String[] lines = Archive.ReadLineFromFile(Path);
            return Get(lines);
        }

        public String[] ConvertToString()
        {
            List<String> lines = new List<String>();

            foreach (Section section in sections)
            {
                lines.Add(String.Format("[{0}]", section.Name));

                foreach (Key key in section.Keys)
                {
                    lines.Add(String.Format("{0}={1}", key.Name, key.Value));
                }
            }

            return lines.ToArray();
        }

        public static IniFile Get(String[] lines)
        {
            IniFile iniTemp = new IniFile();
            Section sectionTemp = Section.None;
            Int32 sectionCount = -1;

            foreach (String line in lines)
            {
                if (Section.IsSection(line))
                {
                    sectionTemp = Section.Parse(line);
                    iniTemp.sections.Add(sectionTemp);
                    sectionCount++;
                }
                else if (Key.IsKey(line))
                {
                    if (sectionCount == -1)
                    {
                        iniTemp.sections.Add(sectionTemp);
                        sectionCount++;
                    }

                    iniTemp.sections[sectionCount].Keys.Add(Key.Parse(line));
                }
            }

            return iniTemp;
        }

        public Section SearchSection(String Name)
        {
            return this.sections.SingleOrDefault(item => item.Name == Name);
        }
    }
}
