using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml;
namespace KTools.Serializer
{
    public class JsonSerializer
    {
        public delegate void ExceptionHandler(Exception e);
        public static void Serialize<T>(T o, string filePath, ExceptionHandler handler = null)
        {
            try
            {
                var sr = new DataContractJsonSerializer(typeof(T));
                var stream = new FileStream(filePath, FileMode.OpenOrCreate);
                sr.WriteObject(stream, o);
                stream.Close();
            }
            catch (Exception e)
            {
                if (handler != null) handler(e);
            }
        }
        public static T DeSerialize<T>(string filePath, ExceptionHandler handler = null)
        {
            try
            {
                var sr = new DataContractJsonSerializer(typeof(T));
                var stream = new FileStream(filePath, FileMode.OpenOrCreate);
                var o = sr.ReadObject(stream);
                T t = (T)o;
                stream.Close();
                return t;
            }
            catch (Exception e)
            {
                if (handler != null) handler(e);
            }
            return default(T);
        }
    }
}
