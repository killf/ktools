using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace KTools.Serializer
{
    public class XMLSerializer
    {
        delegate void ExceptionHandler(Exception e); 
        public static void Serialize<T>(T o, string filePath,ExceptionHandler handler=null)
        {
            try
            {
                var formatter = new XmlSerializer(typeof(T));
                var sw = new StreamWriter(filePath, false);
                formatter.Serialize(sw, o);
                sw.Flush();
                sw.Close();
            }
            catch(Exception e){
                if (handler != null) handler(e);
            }
        }
        public static T DeSerialize<T>(string filePath, ExceptionHandler handler = null)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                StreamReader sr = new StreamReader(filePath);
                T o = (T)formatter.Deserialize(sr);
                sr.Close();
                return o;
            }
            catch (Exception e)
            {
                if (handler != null) handler(e);
            }
            return default(T);
        }
    }
}
