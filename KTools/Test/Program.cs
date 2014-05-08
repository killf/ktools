using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var ls = new List<string>();
            var l = new List<string>();
            ls.Add("Hello world!!!");

            KTools.Serializer.XMLSerializer.Serialize<List<string>>(ls, "xml.txt", (e) => { Console.WriteLine("错误：" + e.ToString()); });
            l = KTools.Serializer.XMLSerializer.DeSerialize<List<string>>("xml.txt", (e) => { Console.WriteLine("错误：" + e.ToString()); });
            Console.WriteLine("XML序列化：" + l[0]);

            var str = "Hello world!!!";
            KTools.Serializer.SoapSerializer.Serialize<string>(str, "soap.txt", (e) => { Console.WriteLine("错误：" + e.ToString()); });
            var s = KTools.Serializer.SoapSerializer.DeSerialize<string>("soap.txt");
            Console.WriteLine("Soap序列化：" + s);

            KTools.Serializer.BinarySerializer.Serialize<List<string>>(ls, "Binary.dat");
            l = KTools.Serializer.BinarySerializer.DeSerialize<List<string>>("Binary.dat");
            Console.WriteLine("Binary序列化：" + l[0]);

            KTools.Serializer.JsonSerializer.Serialize<List<string>>(ls, "Json.txt");
            l = KTools.Serializer.JsonSerializer.DeSerialize<List<string>>("Json.txt");
            Console.WriteLine("Json序列化：" + l[0]);

            Console.WriteLine("测试完毕");
            Console.WriteLine("注：如果显示 Hello world!!! 表示成功！");
            Console.ReadLine();
        }
    }
}
