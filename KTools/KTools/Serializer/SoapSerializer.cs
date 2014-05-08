using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
namespace KTools
{
    public class SoapSerializer
    {
        delegate void ExceptionHandler(Exception e);
        public static void Serialize<T>(T o, string filePath,ExceptionHandler handler=null)
        {
            try
            {
                var formatter = new SoapFormatter();
                var stream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
                formatter.Serialize(stream, o);
                stream.Flush();
                stream.Close();
            }
            catch (Exception e) {
                if (handler != null) handler(e);
            }
        }
        public static T DeSerialize<T>(string filePath, ExceptionHandler handler = null)
        {
            try
            {
                SoapFormatter formatter = new SoapFormatter();
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
