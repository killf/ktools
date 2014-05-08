using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace KTools.Serializer
{
    public class BinarySerializer
    {
        delegate void ExceptionHandler(Exception e);
        public static void Serialize<T>(T o, string filePath,ExceptionHandler handler=null)
        {
            try
            {
                var formatter = new BinaryFormatter();
                var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, o);
                stream.Flush();
                stream.Close();
            }
            catch (Exception e) {
                if (handler != null) handler(e);
            }
        }
        public static T DeSerialize<T>(string filePath,ExceptionHandler handler)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream destream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                T o = (T)formatter.Deserialize(destream);
                destream.Flush();
                destream.Close();
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
