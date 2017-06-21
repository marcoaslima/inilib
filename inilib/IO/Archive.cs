using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace inilib.IO
{
    public class Archive
    {
        public String Content { get; set; }
        public String URL { get; set; }

        public static Archive RealAllFromWeb(String URL)
        {
            Archive arc = new Archive();
            arc.URL = URL;
            arc.Content = String.Empty;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    arc.Content = wc.DownloadString(URL);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error, can't read the remote file", ex);
            }

            return arc;
        }

        public static Archive RealAllFromFile(String Path)
        {
            Archive arc = new Archive();
            arc.URL = Path;
            arc.Content = String.Empty;

            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    arc.Content = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error, can't read the local file", ex);
            }

            return arc;
        }

        public static String[] ReadLineFromFile(String Path)
        {
            List<String> lines = new List<String>();

            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(Path);
                String tempLine = String.Empty;
                while ((tempLine = file.ReadLine()) != null)
                {
                    lines.Add(tempLine);
                }

                file.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error, can't read the remote file", ex);
            }

            return lines.ToArray();
        }

        public override string ToString()
        {
            return this.Content;
        }

        public static Boolean WriteAll(String Content, String Path)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(Path))
                {
                    file.WriteLine(Content);
                    file.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error, can't write the remote file (see permission)", ex);
            }
        }
    }
}
